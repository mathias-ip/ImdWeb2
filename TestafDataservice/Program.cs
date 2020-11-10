using System;
using DataServiceLib;

namespace TestafDataservice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataService = new DataService();
            foreach (var elem in dataService.Gettitle())
            {
                Console.WriteLine(elem);
            }
        }
    }
}
