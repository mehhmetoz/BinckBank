using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http.Headers;
using TestApplication.Models;
using System.Configuration;
using TestApplication.Helpers;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        static string address = ConfigurationManager.AppSettings["endpoint"];

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAdress(string zipcode)
        {
            ZipCodeRequestObject obj = new ZipCodeRequestObject
            {
                ZipCode = zipcode
            };

            BaseRequest<ZipCodeRequestObject> request = new BaseRequest<ZipCodeRequestObject>(obj);
            HttpClient client = new HttpClient() { BaseAddress = new Uri(address) };

            HttpResponseMessage response = client.PostAsJsonAsync<BaseRequest<ZipCodeRequestObject>>("api/GetAdressFromZipCode", request).Result;
            BaseResponse<ZipCodeResponseObject> result = response.Content.ReadAsAsync<BaseResponse<ZipCodeResponseObject>>().Result;

            ZipCodeResponseObject returnModel = new ZipCodeResponseObject
            {
                Adress = result.ResponseObject.Adress.ToString()
            };

            return View("Index", returnModel);
        }
    }
}