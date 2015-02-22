using PingPakistan.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPakistan.DataAccess.DataHandlers
{
    public class Categories
    {
        public categories AddCategory(categories category)
        {
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                db.categories.Add(category);
                db.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                return category;
            }
        }

        public List<categories> getAllCategories(string search)
        {
            List<categories> categoryList = new List<categories>();
            try
            {
                ping_pakistanEntities db = new ping_pakistanEntities();
                categoryList = db.categories.ToList();
            }
            catch (Exception ex)
            {

            }
            return categoryList;
        }
    }
}