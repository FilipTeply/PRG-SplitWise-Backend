using Newtonsoft.Json;
using SplitWise.Model.FacebookResponses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model
{
    public class User
    {
        [Key]
        [Required]
        [JsonProperty("userid")]
        public int UserId { get; set; }

        [JsonProperty("estoken")]
        public string EsToken { get; set; }

        [Required]
        [MinLength(1)]
        [JsonProperty("login")]
        public string Username { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<string> groupNames { get; set; }

        [JsonIgnore]
        public List<UserGroup> UserGroups { get; set; }

        //[NotMapped]
        //public List<string> UserLanguageNamesList
        //{
        //    get
        //    {
        //        return UserLanguages
        //            .Select(ul => ul.Language.LanguageName)
        //            .ToList();
        //    }
        //}

        public User(int userId)
        {
            UserId = userId;
        }

        public User()
        {
        }

        public User(FacebookProfile newUser)
        {
            UserId = newUser.UserId;
        }

        //public void setUserRepos(List<UserRepos> repos)
        //{
        //    string urls = null;
        //    for (int i = 0; i < repos.Count; i++)
        //    {
        //        urls = repos[i].Url + ";" + urls;
        //    }
        //    Repos = urls;
        //}
    }
}
