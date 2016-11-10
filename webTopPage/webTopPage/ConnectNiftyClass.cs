using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace webTopPage
{
    class ConnectNiftyClass
    {
        public ResponseCreateAccount createAccount(string name,string pass)
        {
            var req = (HttpWebRequest)WebRequest.Create("https://mb.api.cloud.nifty.com/2013-09-01/users");
            req.Method = "POST";
            setHedder(req,false);
            SetContent(req, JsonSerializer.createAccount(name, pass));
            return JsonDeserializer.responseCreateAccount(getResponse(req));
        }

        public ResponseLogin login(string name, string pass)
        {
            string txt = URL_enc.loginStr(name, pass);
            var req = (HttpWebRequest)WebRequest.Create(URL_enc.addEnced("https://mb.api.cloud.nifty.com/2013-09-01/login?", txt));
            req.Method = "GET";
            req.ContentType = "application/json";
            setHedder(req, false);
            return JsonDeserializer.responseLogin(getResponse(req));
        }

        public void logout()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://mb.api.cloud.nifty.com/2013-09-01/logout");
            req.Method = "GET";
            req.ContentType = "application/json";
            setHedder(req, true);
            JsonDeserializer.responseLogin(getResponse(req));
        }

        public void updateUser(string ID)
        {

        }

        public string getUser(string objID)
        {
            var req = (HttpWebRequest)WebRequest.Create("https://mb.api.cloud.nifty.com/2013-09-01/users/" + userNiftyInfo.objID);
            setHedder(req, true);
            req.Method = "GET";
            req.ContentType = "application/json";
            return getResponse(req);
        }

        //調整中
        public string setUserData()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://mb.api.cloud.nifty.com/2013-09-01/classes/ownSVM");
            req.Method = "POST";
            setHedder(req, true);
            SetContent(req, JsonSerializer.createInputData(userNiftyInfo.objID,"TEST"));
            return getResponse(req);
        }

        //調整中
        public string getUserData(string username)
        {
            var req = (HttpWebRequest)WebRequest.Create("https://mb.api.cloud.nifty.com/2013-09-01/classes/" + username+"/" + userNiftyInfo.objID);
            setHedder(req, true);
            req.Method = "GET";
            req.ContentType = "application/json";
            return getResponse(req);
        }
        public void uploadFile(string fileName)
        {

        }

        private string getResponse(HttpWebRequest request)
        {
            string res = "";
            using (var webRes = (HttpWebResponse)request.GetResponse())
                    using (var sr = new StreamReader(webRes.GetResponseStream()))
                    {
                        res = sr.ReadToEnd();
                    }
            return res;
        }

        private void setHedder(HttpWebRequest request,bool withSession)
        {
            const string appKey = "684097527873dc4775fc28d4c98740708a906f5310dc83b821f5036c3ea43ddb";
            const string clientKey = "5b8dd0fcb4bf40d9211a3faddd55d26eed31d7f98f610942c9af51947440182f";
            var now = DateTime.Now;
            var query = "";

            var parameters = new List<string>() {
                   "SignatureMethod=HmacSHA256",
                   "SignatureVersion=2",
                   "X-NCMB-Application-Key=" + appKey,
                   "X-NCMB-Timestamp="+ now.ToString("yyyy-MM-ddTHH:mm:sszzzz")
                };
            if (request.RequestUri.Query != null && request.RequestUri.Query.Length > 0)
                foreach (var item in request.RequestUri.Query.Substring(1).Split('&'))
                    parameters.Add(item);


            var buf = new StringBuilder(64);
            foreach (var item in parameters.OrderBy(x => x.Split('=')[0], StringComparer.Ordinal))
            {
                if (buf.Length > 0)
                    buf.Append('&');
                buf.Append(item);
            }
            query = buf.ToString();


            var signature = new StringBuilder(64)
               .Append(request.Method).Append('\n')
               .Append(request.RequestUri.Host).Append('\n')
               .Append(request.RequestUri.AbsolutePath).Append('\n')
               .Append(query)
               .ToString();

            using (var hmacsha256 = new HMACSHA256(Encoding.ASCII.GetBytes(clientKey)))
            {
                if(userNiftyInfo.session != "" || withSession) request.Headers.Add("X-NCMB-Apps-Session-Token", userNiftyInfo.session);
                request.Headers.Add("X-NCMB-Application-Key", appKey);
                request.Headers.Add("X-NCMB-Signature", Convert.ToBase64String(hmacsha256.ComputeHash(Encoding.ASCII.GetBytes(signature))));
                request.Headers.Add("X-NCMB-Timestamp", now.ToString("yyyy-MM-ddTHH:mm:sszzzz"));
            }
        }

        private static void SetContent(HttpWebRequest request, string str)
        {
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] data = enc.GetBytes(str);

            request.ContentType = "application/json";

            request.ContentLength = data.Length;

            Stream st = request.GetRequestStream();
            st.Write(data, 0, data.Length);
            st.Close();
        }
    }

}

