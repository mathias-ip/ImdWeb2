
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    class Program
    {
        public static User CurrentUser = null;

        static void Main(string[] args)
        {

            var dataService = new DataService();
       /*     foreach (var elem in dataService.Gettitle())
            {
                Console.WriteLine(elem);
            } */
        }
    }
}
