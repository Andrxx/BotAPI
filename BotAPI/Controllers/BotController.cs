using BotAPI.BLL;
using BotAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotAPI.Controllers
{
    public class BotController : Controller
    {
        ViberRequests vr = new ViberRequests();
        string vbToken = "4addaa2c4da7dee0-1e71c2088f77e61c-2ffe40d0ad8cc31c";
        Sender sender = new Sender { name = "Ковалев", avatar = "" };
       

        [HttpPost]
        public JsonResult Setup()
        {
            JObject _response = new JObject();
            List<string> listValues = new List<string>();
            foreach (string key in Request.Form.AllKeys)
            {
                listValues.Add(Request.Form[key]);
            }
          
            using (StreamWriter w = new StreamWriter(Server.MapPath("~/files/data.txt"), true))
            {
                foreach (string line in listValues)
                {
                    w.WriteLine(line);
                }
            }


            string _event = Request.Form["event"];
            if (_event == "webhook")
            {
                _response.Add("status", 0);
                _response.Add("status_message", "ok");

            }

            if (_event == "subscribed")
            {
                _response.Add("status", 0);
                _response.Add("status_message", "ok");
            }

            if (_event == "message")
            {
                _response.Add("status", 0);
                _response.Add("status_message", "ok");
            }

            return Json(_response.ToString());
        }

        public JsonResult TextTest()
        {
            using (StreamWriter w = new StreamWriter(Server.MapPath("~/files/TestData.txt"), true))
            {
                w.WriteLine("Text after button pressed"); 
            }

            return Json("result");
        }
    }
}