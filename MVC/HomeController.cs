using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Data;
using System.ComponentModel;
using System.IO;

namespace TwistedTreeLineApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getjson(string queryString)
        {
            string key = "f0d78781-85bd-4ae9-a68c-08c45f20271f";
            string UrlRequest = "https://na.api.pvp.net/api/lol/NA/v1.2/" +
                                 queryString +
                                 "?api_key=" + key;
            //try
            //{

            //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(UrlRequest);

            //    using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
            //    {
            //        return Json(response, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return null;
            //}

            var request = WebRequest.Create(UrlRequest);
            request.ContentType = "application/json; charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var sr = new StreamReader(response.GetResponseStream());

            return Json(sr.ReadToEnd(), JsonRequestBehavior.AllowGet);
        }

    }
}