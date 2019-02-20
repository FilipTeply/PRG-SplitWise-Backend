using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "group_name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Group name is required.")]
        public string GroupName { get; set; }

        [JsonIgnore]
        public List<UserGroup> UserGroups { get; set; }

        public Group()
        {
        }

        public Group(string groupName)
        {
            GroupName = groupName;
        }
    }
}
