using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataServiceLib
{
    public class Databasecontext : DbContext
    {
        
        public static readonly ILoggerFactory MyLoggerFactory //Tilføjer konsol
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            optionsBuilder.UseNpgsql("host=localhost;db=imdb;uid=postgres;pwd=191191Ippe"); //Indtaster host, databasenavn, brugernavn og password

        }

        internal static object FromSql(string v)
        {
            throw new NotImplementedException();
        }
         //Henter funktioner fra databasen
        public DbSet<NameSearchResult> NameSearchResult { get; set; }
        public DbSet<MovieSearchResult> MovieSearchResult { get; set; }

        public DbSet<User> User { get; set; }


        public DbSet<createuser> createuser { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //henter værdier fra databasen
            modelBuilder.Entity<NameSearchResult>().HasNoKey();
            modelBuilder.Entity<NameSearchResult>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<NameSearchResult>().Property(x => x.category).HasColumnName("category");

            modelBuilder.Entity<MovieSearchResult>().HasNoKey();
            modelBuilder.Entity<MovieSearchResult>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<MovieSearchResult>().Property(x => x.originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<MovieSearchResult>().Property(x => x.averagerating).HasColumnName("averagerating");

            modelBuilder.Entity<bookmark>().HasNoKey();
            modelBuilder.Entity<bookmark>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<bookmark>().Property(x => x.titleid).HasColumnName("titleid");
            modelBuilder.Entity<bookmark>().Property(x => x.nameid).HasColumnName("nameid");

            
           /* modelBuilder.Entity<createuser>().HasNoKey();
            modelBuilder.Entity<createuser>().ToTable("users");
            modelBuilder.Entity<createuser>().Property(x => x.username).HasColumnName("username");
            modelBuilder.Entity<createuser>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<createuser>().Property(x => x.email).HasColumnName("email");
           */
            modelBuilder.Entity<SearchHistory>().HasKey(x => new { x.Userid, x.SearchDate });
            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Userid).HasColumnName("userid");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchEntry).HasColumnName("searchentry");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchDate).HasColumnName("searchdate");

            modelBuilder.Entity<User>().HasNoKey();
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(x => x.username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(x => x.email).HasColumnName("email");



        }

    }


}