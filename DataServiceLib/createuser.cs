﻿namespace DataServiceLib
{
    public class createuser //henter username, password og mail til oprettelse af bruger
    {
        public int? id {get; set;}
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}