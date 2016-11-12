using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    class JsonDeserializer
    {
        public static ResponseCreateAccount responseCreateAccount(string jsonStr)
        {
            return JsonConvert.DeserializeObject<ResponseCreateAccount>(jsonStr);
        }

        public static ResponseLogin responseLogin(string jsonStr)
        {
            return JsonConvert.DeserializeObject<ResponseLogin>(jsonStr);
        }

        public static ResponseDataset responseDataset(string jsonStr)
        {
            return JsonConvert.DeserializeObject<ResponseDataset>(jsonStr);
        }


        public static ResponseSVM responsesvm(string jsonStr)
        {
            return JsonConvert.DeserializeObject<ResponseSVM>(jsonStr);
        }
    }
}
