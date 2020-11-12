using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;



namespace DataServiceLib
{ //test tesdt Mathias er god

   
    public class DataService //: IDataService
    {
        public IList<Title> Gettitle()

        {
            var ctx = new Databasecontext();
            ctx.SaveChanges();
            return ctx.title.ToList();
        }

        public ILst<SearchResult> Search(string arg)
        {
            var ctx = new Databasecontext();

            ctx.SearchResults.

            return null;
        }

        /*static void findingname(String[]args)
        {
            var connectionString = "host=localhost;db=imdb;uid=postgres;pwd=";
            var connection = new NpgsqlConnection (connectionString);
            connection.Open;

            var cmd = NpgsqlCommand("select * from findingname('%joe%')", connection);

            var reader = cmd.Executereader();

            while (reader.read())
            {

                Console.WriteLine($"{reader.GetInt32()}");
            }
        }*/
    }
}
