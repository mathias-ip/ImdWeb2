using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;



namespace DataServiceLib
{ 

   
    public class DataService 
    {
        private List<User> _users = testdata.Users;
        private object _db;

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

        public IList<NameSearchResult> SearchName(string arg, int page, int pageSize)
        {
            var ctx = new Databasecontext();
            Console.WriteLine(arg);
            return ctx.NameSearchResult.FromSqlInterpolated($"select * from findingname({arg.ToLower()})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
        }


        public IList<structuredStringSearch> StringSearch(string arg1, string arg2, string arg3, string arg4, string arg5)
        {
            var ctx = new Databasecontext();

            var v = ctx.structuredStringSearch.FromSqlInterpolated($"select * from structured_string_search({arg1},{arg2}, {arg3}, {arg4}, {arg5})");

            return v.ToList();

        }

        public IList<MovieSearchResult> SearchMovie(string arg, int page, int pageSize)
        {
            var ctx = new Databasecontext();
            Console.WriteLine(arg);
            return ctx.MovieSearchResult.FromSqlInterpolated($"select * from findingmovie({arg.ToLower()})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
        }

        public int GetSearchMovieCount(string arg)
        {
            var ctx = new Databasecontext();
            var cmd = ctx.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "select * from findingmoviecount('" + arg.ToLower() + "')";
            cmd.Connection.Open();
            return (int)cmd.ExecuteScalar();


        }

        public int GetSearchNameCount(string arg)
        {
            var ctx = new Databasecontext();
            var cmd = ctx.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "select * from findingnamecount('" + arg.ToLower() + "')";
            cmd.Connection.Open();
            return (int)cmd.ExecuteScalar();


        }


        /* public IList<findingmovie> Search2(string arg)
          {
              var ctx = new Databasecontext();

              var p = ctx.findingmovie.FromSqlInterpolated($"select * from findingmovie({arg})");

              return p.ToList();
          }*/


        public void Createuser(User user)
        {
            var ctx = new Databasecontext();
            ctx.Database.ExecuteSqlInterpolated($"select createUser({user.username},{user.password},{user.email})");
           

        }

        
    }
}
