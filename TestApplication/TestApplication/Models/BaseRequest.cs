using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class BaseRequest<T>
    {
        public RequestHeader Header { get; set; }

        public T RequestObject { get; set; }

        public BaseRequest(T request)
        {
            RequestObject = request;
            Header = new RequestHeader();
        }
    }
}
