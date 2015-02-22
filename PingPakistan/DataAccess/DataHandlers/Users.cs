using PingPakistan.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPakistan.DataAccess.DataHandlers
{
    public class Users
    {
        public int AddUser(users user)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                db.users.Add(user);
                db.SaveChanges();
                return user.id;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public users GetUserByUsername(string username)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                return db.users.FirstOrDefault(u => u.username == username);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Authenticate(string username, string password)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                var user = db.users.Where(u => u.username == username && u.password == password);
                if (user.Count() > 0)
                {
                    return true;
                } 
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<users> getUsers(string search)
        {
            List<users> usersList = new List<users>();
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                usersList = db.users.ToList();
            }
            catch (Exception ex)
            {
                
            }
            return usersList;
        }

        public bool VerifyCode(int user_id, string code)
        {
            bool isVerified = false;
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                var user = db.users.Where(p => p.id == user_id && p.verification_code == code);
                if(user.Count() > 0)
                {
                    isVerified = true;
                }
            }
            catch(Exception ex)
            {

            }
            return isVerified;
        }
    }
}