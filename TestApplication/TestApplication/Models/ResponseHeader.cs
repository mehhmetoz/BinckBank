using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class ResponseHeader
    {
        public bool ResponseStatus { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseDetailMessage { get; set; }
    }
}
