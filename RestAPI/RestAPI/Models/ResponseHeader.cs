using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ResponseHeader
    {
        public bool ResponseStatus { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseDetailMessage { get; set; }
    }
}