using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using TestApplication.Models;

namespace TestApplication.Helpers
{
    public class TextMediaTypeFormatter : MediaTypeFormatter
    {
        public TextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                var memoryStream = new MemoryStream();
                readStream.CopyTo(memoryStream);
                var s = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                taskCompletionSource.SetResult(s);
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
            return taskCompletionSource.Task;
        }
        //public override Task<object>  WriteToStreamAsync

        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
        public override bool CanWriteType(Type type)
        {
            if (type == typeof(BaseRequest<ZipCodeRequestObject>))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<BaseRequest<ZipCodeRequestObject>>);
                return enumerableType.IsAssignableFrom(type);
            }
        }
    }
}