using System;
using DataServiceLib;

namespace TestafDataservice //Gammel test af dataservice for at se om det var muligt at udtrække date fra SQL databasen
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
