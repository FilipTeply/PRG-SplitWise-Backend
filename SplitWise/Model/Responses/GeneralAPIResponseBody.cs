using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class GeneralAPIResponseBody
    {
        [JsonProperty("status", Order = -2, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}
