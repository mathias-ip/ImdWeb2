
namespace DataServiceLib
{

    public class User //henter bruger data
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string Salt { get; set; }
    }
}
