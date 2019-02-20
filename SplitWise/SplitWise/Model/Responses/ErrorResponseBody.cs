using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class ErrorResponseBody : GeneralAPIResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorResponseBody(string errorMessage)
        {
            Status = "error";
            Message = errorMessage;
        }
    }
}
