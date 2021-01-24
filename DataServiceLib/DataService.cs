using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace DataServiceLib
{ 

   
    public class DataService //indholder data og funktioner
    {
        private List<User> _users = testdata.Users; //Henter dummy data til authorization

        public User GetUser(string username) // Current user, hentet fra dummy data
        {

            return _users.FirstOrDefault(x => x.username == username);

        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.userid == id);
        }

        public IList<NameSearchResult> SearchName(string arg, int page, int pageSize) //Laver search name, ved at hente i database context
        {
            var ctx = new Databasecontext();
            Console.WriteLine(arg);
            return ctx.NameSearchResult.FromSqlInterpolated($"select * from findingname({arg.ToLower()})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
        }




        public IList<MovieSearchResult> SearchMovie(string arg, int page, int pageSize) //Søger search movie, ved at hente fra database context
        {
            var ctx = new Databasecontext();
            Console.WriteLine(arg);
            return ctx.MovieSearchResult.FromSqlInterpolated($"select * from findingmovie({arg.ToLower()})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
        }

        public int GetSearchMovieCount(string arg) //Movie tæller, som  holder styr på mængden af film som der bliver hentet fra listen
        {
            var ctx = new Databasecontext();
            var cmd = ctx.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "select * from findingmoviecount('" + arg.ToLower() + "')";
            cmd.Connection.Open();
            return (int)cmd.ExecuteScalar();


        }

        public int GetSearchNameCount(string arg) //Navne tæller, som holder styr på mængden af film som der bliver hentet fra listen
        {
            var ctx = new Databasecontext();
            var cmd = ctx.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "select * from findingnamecount('" + arg.ToLower() + "')";
            cmd.Connection.Open();
            return (int)cmd.ExecuteScalar();


        }


        public void Createuser(User user) //indsætter brugernavn, password og email i databasen under "user"
        {
            var ctx = new Databasecontext();
            ctx.Database.ExecuteSqlInterpolated($"select createUser({user.username},{user.password},{user.email})");
           

        }

        public User GetUser(string username, string password)
        {
            var ctx = new Databasecontext();
            return ctx.User.FirstOrDefault(x => x.username == username && x.password == password);
        }

    }
}
