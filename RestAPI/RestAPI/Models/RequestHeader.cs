using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class RequestHeader
    {
        // <summary>
        /// Gets or sets ZipCode
        /// </summary>
        public string ZipCode { get; set; }

        public RequestHeader()
        {
            ZipCode = "17121";
        }
    }
}