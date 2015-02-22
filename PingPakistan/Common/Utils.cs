using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPakistan.Common
{
    public class Utils
    {
        public static string GenerateVerficationCode()
        {
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 4)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}