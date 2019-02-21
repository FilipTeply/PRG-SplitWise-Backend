using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class LoginResponseBody : GeneralAPIResponseBody
    {
        [JsonProperty("userid")]
        public long UserId { get; set; }

        [JsonProperty("fbtoken")]
        public string FbToken { get; set; }

        [JsonProperty("name")]
        public string Username { get; set; }

        [JsonProperty("estoken")]
        public string EsToken { get; set; }

        [JsonProperty("picture")]
        public string PhotoUrl { get; set; }

        //public LoginResponseBody()
        //{
        //}

        //public LoginResponseBody(User user)
        //{
        //    Status = "ok";
        //    UserId = user.UserId;
        //    Username = user.Username;
        //    //EsToken = user.EsToken;
        //    PhotoUrl = user.PhotoUrl;

        //    //UserLanguageNamesList = user.UserLanguageNamesList;
        //}

        ////[JsonProperty("facebook_token")]
        ////public string FacebookToken { get; set; }

        //public LoginResponseBody(string fbToken)
        //{
        //    Status = "ok";
        //    FbToken = fbToken;
        //}
        
        public LoginResponseBody(string esToken)
        {
            Status = "ok";
            EsToken = esToken;
        }
    }
}
