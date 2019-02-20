﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.Model.Responses
{
    public class OKResponseBody : GeneralAPIResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public OKResponseBody(string message)
        {
            Status = "ok";
            Message = message;
        }
    }
}
