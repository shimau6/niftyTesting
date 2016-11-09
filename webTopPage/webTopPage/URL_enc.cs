using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    class URL_enc
    {
        public static string enc(string txt)
        {
            return System.Web.HttpUtility.UrlPathEncode(txt);
        }

        public static string addEnced(string url,string addtion)
        {
            return url + System.Web.HttpUtility.UrlPathEncode(addtion);
        }

        public static string loginStr(string name, string pass)
        {
            return @"userName=" + name + @"&password=" + pass;
        }
    }
}
