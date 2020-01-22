using BotAPI.BLL;
using BotAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace BotAPI.Controllers
{
    public class RequestController : Controller
    {
        ViberRequests vr = new ViberRequests();
        string vbToken = "4addaa2c4da7dee0-1e71c2088f77e61c-2ffe40d0ad8cc31c";
        Sender sender = new Sender { name = "Ковалев", avatar = "" };

        public async System.Threading.Tasks.Task<ActionResult> GetWebhookAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            string _botUri = Request.Form["botUri"];
            string sethook = await vr.GetWebhook(vbToken, "https://yourchat.io/");
            return Json(sethook, JsonRequestBehavior.AllowGet);
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteWebhookAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            bool sethook = await vr.RemoveWebhook(_vbToken);
            return Json(sethook);
        }
        public async System.Threading.Tasks.Task<ActionResult> SendMsgAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            string _userID = Request.Form["userID"];
            string _message = Request.Form["msg"];
            Sender _sender = new Sender
            {
                name = Request.Form["sender[name]"],
                avatar = Request.Form["sender[avatar]"]
            };

            string msg = await vr.SendMessage(_vbToken, _userID, _sender, _message);
            return Json(msg);
        }

        public async System.Threading.Tasks.Task<ActionResult> SendBroadcastMsgAsync()
        {
            List<string> _usersID = new List<string>();
            _usersID.Add(@"1Xyc2cGDSAi2nMbUjyhr6w==");
            _usersID.Add(@"1Xyc2cGDSAi2nmngUjyhr6w==");
            _usersID.Add(@"1Xydc2cGDSAi2nMbUjydcfw==");
            string _vbToken = Request.Form["viberToken"];
            string _message = Request.Form["msg"];
            Sender _sender = new Sender
            {
                name = Request.Form["sender[name]"],
                avatar = Request.Form["sender[avatar]"]
            };

            string msg = await vr.SendBroadcastMessage(_vbToken, _usersID, _sender, _message);
            return Json(msg);
        }
    }
}