using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class TokenResponseBody : GeneralAPIResponseBody
    {
        [JsonProperty("facebook_token")]
        public string FacebookToken { get; set; }

        public TokenResponseBody(string facebookToken)
        {
            Status = "ok";
            FacebookToken = facebookToken;
        }
    }
}
