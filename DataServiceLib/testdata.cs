using System.Collections.Generic;

namespace DataServiceLib
{

    class testdata
    {
        public static List<User> Users { get; set; }
        static testdata()
        {
            Users = new List<User>
            {
                new User {userid = 1, email = "Test User", username = "testing"}
            };
        }
    }
}
