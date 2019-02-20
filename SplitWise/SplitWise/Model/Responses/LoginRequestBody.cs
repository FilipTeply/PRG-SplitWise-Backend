using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class LoginRequestBody
    {
        [JsonProperty("userid")]
        public int UserId { get; set; }

        [JsonProperty("fbtoken")]
        public string FbToken { get; set; }
    }
}
