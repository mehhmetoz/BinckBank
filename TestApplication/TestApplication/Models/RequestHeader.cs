using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class RequestHeader
    {
        // <summary>
        /// Gets or sets ZipCode
        /// </summary>
        public string ZipCode { get; set; }

       public RequestHeader()
        {
            ZipCode = "30222";
        }
    }
}
