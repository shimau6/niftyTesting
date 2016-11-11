using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    class JsonSerializer
    {
        public static string createAccount(string username,string password)
        {
            var data = new Json_ForCreateAccount();
            data.username = username;
            data.password = password;
            return JsonConvert.SerializeObject(data);
        }

        public static string createInputData(string parentID, string svm)
        {
            var data = new Json_ForInputData();
            data.ParentObjectID = parentID;
            data.SVM = svm;
            return JsonConvert.SerializeObject(data);
        }

        public static string oneJson(string A, string B)
        {
            return @"{""" + A + @""": """ + B + @"""}";
        }
    }


}
