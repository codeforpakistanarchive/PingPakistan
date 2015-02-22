using PingPakistan.DataAccess.Context;
using PingPakistan.DataAccess.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PingPakistan.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/
        public ActionResult Index()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            return View();
        }

        public posts NewPost(posts post)
        {
            try
            {
                Posts posts = new Posts();
                post.agree_count = 0;
                post.disagree_count = 0;
                post.date_added = DateTime.Now;
                post.is_approved = true;
                post.is_deleted = true;                
                posts.AddPost(post);
                return post;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
	}
}