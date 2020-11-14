using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib
{
    /* class User
     {

         public int userid { get; set; }

         public string username { get; set; }

         public string password { get; set; }

         public string email { get; set; }


         public override string ToString()
         {
             return $"userid = {userid}, ´username = {username}, password = {password}, email = {email}";

         }
     } */
    public class User
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string Salt { get; set; }
    }
}
