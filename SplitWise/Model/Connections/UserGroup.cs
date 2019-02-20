using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model
{
    public class UserGroup
    {
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public UserGroup(int userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}
