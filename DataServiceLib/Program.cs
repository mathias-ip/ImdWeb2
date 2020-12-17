
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib //Test af authorization
{
    class Program
    {
        public static User CurrentUser = null;

        static void Main(string[] args)
        {

            var dataService = new DataService();
        }
    }
}
