using System.Collections.Generic;

namespace DataServiceLib
{

    class testdata //Test bruger til at teste authorization med
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
