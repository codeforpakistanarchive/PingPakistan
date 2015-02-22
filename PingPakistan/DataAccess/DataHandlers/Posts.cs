using PingPakistan.Common;
using PingPakistan.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPakistan.DataAccess.DataHandlers
{
    public class Posts
    {
        public posts AddPost(posts post)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                db.posts.Add(post);
                db.SaveChanges();
                return post;
            }
            catch (Exception ex)
            {
                return post;
            }
        }

        public bool UpdateApproveStatus(int post_id, bool status)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                var _post = db.posts.FirstOrDefault(p => p.id == post_id);
                if(_post != null)
                {
                    _post.is_approved = status;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePost(int post_id)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                var _post = db.posts.FirstOrDefault(p => p.id == post_id);
                if (_post != null)
                {
                    _post.is_deleted = true;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<posts> getPostsByUserId(int user_id, string search)
        {
            List<posts> postsList = new List<posts>();
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                postsList = db.posts.Where(p => p.user_id == user_id && p.is_approved == true && p.is_deleted == true).ToList();
            }
            catch (Exception ex)
            {

            }
            return postsList;
        }

        public List<posts> getPostsByCategoryId(int category_id, string search)
        {
            List<posts> postsList = new List<posts>();
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                postsList = db.posts.Where(p => p.category_id == category_id && p.is_approved == true && p.is_deleted == true).ToList();
            }
            catch (Exception ex)
            {

            }
            return postsList;
        }

        public List<posts_view_model> getAllPosts(string search)
        {
            List<posts_view_model> postsList = new List<posts_view_model>();
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                var pposts = (from post in db.posts
                              join user in db.users on post.user_id equals user.id
                              join category in db.categories on post.category_id equals category.id
                              where post.is_approved != true && post.is_deleted != true
                              select new posts_view_model
                              {
                                  post_id = post.id,
                                  user_id = post.user_id,
                                  post_text = post.text,
                                  date_added = post.date_added,
                                  agree_count = post.agree_count,
                                  disagree_count = post.disagree_count,
                                  username = user.username,
                                  category_name = category.name,
                                  category_id = category.id
                              });
                postsList = pposts.ToList();
            }
            catch (Exception ex)
            {

            }
            return postsList;
        }
    }
}