//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PingPakistan.DataAccess.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string ip_address { get; set; }
        public string verification_code { get; set; }
        public Nullable<bool> is_verified { get; set; }
        public Nullable<System.DateTime> date_added { get; set; }
        public string phone_number { get; set; }
    }
}