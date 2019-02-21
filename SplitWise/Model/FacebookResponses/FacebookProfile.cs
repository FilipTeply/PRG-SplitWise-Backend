using Newtonsoft.Json;
using SplitWise.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.FacebookResponses
{
    public class FacebookProfile : GeneralAPIResponseBody
    {
        [JsonProperty("userid")]
        public long UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("estoken")]
        public string EsToken { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        public FacebookProfile()
        {

        }

        public FacebookProfile(User user)
        {
            UserId = user.UserId;
            Username = user.Username;
            EsToken = user.EsToken;
            PhotoUrl = user.PhotoUrl;
            Balance = user.Balance;

            //UserLanguageNamesList = user.UserLanguageNamesList;
           
        }

    }
}
