using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataServiceLib
{
    public class Databasecontext : DbContext
    {
        
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql("host=localhost;db=imdb;uid=postgres;pwd=191191Ippe");
        }

        internal static object FromSql(string v)
        {
            throw new NotImplementedException();
        }

        public DbSet<NameSearchResult> NameSearchResult { get; set; }
        public DbSet<MovieSearchResult> MovieSearchResult { get; set; }

        public DbSet<createuser> createuser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
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

            modelBuilder.Entity<createuser>().HasNoKey();
            modelBuilder.Entity<createuser>().Property(x => x.username).HasColumnName("username");
            modelBuilder.Entity<createuser>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<createuser>().Property(x => x.email).HasColumnName("email");

        }
    }


}