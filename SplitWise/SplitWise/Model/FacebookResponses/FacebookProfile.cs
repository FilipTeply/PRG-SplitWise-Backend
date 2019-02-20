using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.FacebookResponses
{
    public class FacebookProfile
    {
        [JsonProperty("userid")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("estoken")]
        public string EsToken { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }

    }
}
