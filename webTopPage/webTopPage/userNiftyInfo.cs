using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    class userNiftyInfo
    {
        public static string username = "";
        public static string password = "";
        public static string session = "";
        public static string objID = "";
        public static string svmID;

        public static void set(ResponseLogin r)
        {
            username = r.userName;
            session = r.sessionToken;
            objID = r.objectId;
            svmID = r.svm;
        }
    }
}
