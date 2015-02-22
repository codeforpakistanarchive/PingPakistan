using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPakistan.Common
{
    public class Modals
    {
    }

    public class posts_view_model
    {
        public int post_id { get; set; }
        public int? user_id { get; set; }
        public string post_text { get; set; }
        public DateTime? date_added { get; set; }
        public int? agree_count { get; set; }
        public int? disagree_count { get; set; }
        public string username { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
    }

}