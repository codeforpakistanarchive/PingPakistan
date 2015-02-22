using PingPakistan.Common;
using PingPakistan.DataAccess.Context;
using PingPakistan.DataAccess.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PingPakistan.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        public ActionResult Index()
        {
            return View();
        }

        public int AddUser(users user)
        {
            Users users = new Users();
            user.verification_code = Utils.GenerateVerficationCode();
            user.is_verified = false;
            user.date_added = DateTime.Now;
            var id = users.AddUser(user);
            SmileSMS.Send(user.phone_number, "Verification Code For Ping Pakistan: " + user.verification_code);
            return id;
        }

        public bool VerifyCode(int user_id, string code)
        {
            Users users = new Users();
            var isVerified = users.VerifyCode(user_id, code);
            if (isVerified)
            {
                Session.Add("pp_user_id", user_id);
            }
            return isVerified;
        }

        public object Authenticate(string username, string password)
        {
            Users users = new Users();
            var isAuthenticated = users.Authenticate(username, password);
            var user = users.GetUserByUsername(username);
            Session.Add("pp_user_id", user.id);
            string status = "error";
            if (isAuthenticated)
            {
                status = "ok";
            }
            return new { status = status };
        }
        public string Signout()
        {
            Session.Clear();
            return "ok";
        }

	}
}