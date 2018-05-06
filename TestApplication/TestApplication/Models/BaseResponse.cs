using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class BaseResponse<T>
    {
        public T ResponseObject { get; set; }

        public ResponseHeader Header { get; set; }

        public BaseResponse(T responseObject)
        {
            ResponseObject = responseObject;

            Header = new ResponseHeader
            {
                ResponseCode = "1",
                ResponseMessage = "Success",
                ResponseDetailMessage = "Success",
                ResponseStatus = true
            };
        }
    }
}
