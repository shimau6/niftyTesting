using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    [JsonObject("user")]
    public class Json_ForCreateAccount
    {
        [JsonProperty("userName")]
        public string username { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }

    [JsonObject("user")]
    public class Json_ForInputData
    {
        [JsonProperty("ParentObjectID")]
        public string ParentObjectID { get; set; }
        [JsonProperty("SVM")]
        public string SVM { get; set; }
    }

    [JsonObject("user")]
    public class Json_ForSVMData
    {
        [JsonProperty("svm")]
        public string svm { get; set; }
        [JsonProperty("user")]
        public string user { get; set; }
    }

    [JsonObject("user")]
    public class ResponseCreateAccount
    {
        [JsonProperty("createDate")]
        public string createDate { get; set; }
        [JsonProperty("objectId")]
        public string objectId { get; set; }
        [JsonProperty("sessionToken")]
        public string sessionToken { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }

    }

    [JsonObject("user")]
    public class ResponseLogin
    {
        [JsonProperty("createDate")]
        public string createDate { get; set; }
        [JsonProperty("objectId")]
        public string objectId { get; set; }
        [JsonProperty("sessionToken")]
        public string sessionToken { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("updateDate")]
        public string updateDate { get; set; }
        [JsonProperty("svm")]
        public string svm { get; set; }
    }

    [JsonObject("user")]
    public class ResponseDataset
    {
        [JsonProperty("objectId")]
        public string objectId { get; set; }
    }
}
