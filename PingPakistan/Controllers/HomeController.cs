using PingPakistan.Common;
using PingPakistan.DataAccess.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PingPakistan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                //var sms = SmileSMS.Send("03445810804", "test");
                Categories cats = new Categories();
                Posts posts = new Posts();
                ViewBag.categories = cats.getAllCategories("");
                ViewBag.posts = posts.getAllPosts("");
                ViewBag.isLoggedIn = false;
                if (Session["pp_user_id"] != null)
                {
                    ViewBag.isLoggedIn = true;
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

    }
}