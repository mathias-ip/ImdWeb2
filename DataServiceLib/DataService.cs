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
        private List<User> _users = testdata.Users;

        public IList<Title> Gettitle(int id)

        {
            var ctx = new Databasecontext();
            ctx.SaveChanges();
            return ctx.title.ToList();
        }
        public User GetUser(string username)
        {

            return _users.FirstOrDefault(x => x.username == username);

        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.userid == id);
        }

        public IList<SearchResult> Search(string arg)
        {
            var ctx = new Databasecontext();

            var q = ctx.SearchResults.FromSqlInterpolated($"select * from findingname({arg})");

            return q.ToList();
        }

        public IList<structuredStringSearch> StringSearch(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            var ctx = new Databasecontext();

            var v = ctx.structuredStringSearch.FromSqlInterpolated($"select * from structured_string_search({arg1},{arg2}, {arg3}, {arg4}, {arg5})");

            return v.ToList();

        }

       

        public IList<findingmovie> Search2(string arg)
        {
            var ctx = new Databasecontext();

            var p = ctx.findingmovie.FromSqlInterpolated($"select * from findingmovie({arg})");

            return p.ToList();
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
