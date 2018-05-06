using System;
using System.Web.Http;
using RestAPI.Models;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;

namespace RestAPI.Controllers
{ 
    [RoutePrefix("api")]
    public class RestAppController : ApiController
    {

        [Route("GetAdressFromZipCode")]
        [HttpPost, ActionName("GetAdressFromZipCode")]
        public BaseResponse<ZipCodeResponseObject> GetAdressFromZipCode([FromBody]BaseRequest<ZipCodeRequestObject> request)
        {
            BaseResponse<ZipCodeResponseObject> response;
            ZipCodeResponseObject adress = new ZipCodeResponseObject();
            string zipcode = request.RequestObject.ZipCode.ToString();
            try
            {
                string patern = @"\d{5}";
                Regex r = new Regex(patern);
                string fileName = HostingEnvironment.MapPath(@"~/App_Data/sampleadress.txt");
                StringBuilder sb = new StringBuilder();
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                        if (line.Contains(zipcode))
                            sb.Append(line + "<br/>");
                }


                adress.Adress = sb.ToString();             
                response = new BaseResponse<ZipCodeResponseObject>(adress);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<ZipCodeResponseObject>(new ZipCodeResponseObject());
                response.Header.ResponseCode = "-1";
                response.Header.ResponseMessage = ex.Message;
                response.Header.ResponseDetailMessage = ex.InnerException == null ? string.Empty : ex.InnerException.ToString();
                response.Header.ResponseStatus = false;
            }
            return response;
        }
    }
}
