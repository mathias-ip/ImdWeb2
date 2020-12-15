using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            optionsBuilder.UseNpgsql("host=localhost;db=imdb;uid=postgres;pwd=Jegersej19");
        }

        internal static object FromSql(string v)
        {
            throw new NotImplementedException();
        }

        public DbSet<SearchResult> SearchResults { get; set; }

        public DbSet<structuredStringSearch> structuredStringSearch { get; set; }

        public DbSet<findingmovie> findingmovie { get; set; }

        public DbSet<Title> title { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Title>().ToTable("title");
            modelBuilder.Entity<Title>().Property(x => x.titleid).HasColumnName("titleid");
            modelBuilder.Entity<Title>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Title>().Property(x => x.titletype).HasColumnName("titletype");
         

            modelBuilder.Entity<SearchResult>().HasNoKey();
            modelBuilder.Entity<SearchResult>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<SearchResult>().Property(x => x.category).HasColumnName("category");


            modelBuilder.Entity<structuredStringSearch>().HasNoKey();
            modelBuilder.Entity<structuredStringSearch>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<structuredStringSearch>().Property(x => x.plot).HasColumnName("plot");
            modelBuilder.Entity<structuredStringSearch>().Property(x => x.characters).HasColumnName("characters");
            modelBuilder.Entity<structuredStringSearch>().Property(x => x.primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<structuredStringSearch>().Property(x => x.userid).HasColumnName("userid");


            modelBuilder.Entity<bookmark>().HasNoKey();
            modelBuilder.Entity<bookmark>().Property(x => x.userid).HasColumnName("userid");
            modelBuilder.Entity<bookmark>().Property(x => x.titleid).HasColumnName("titleid");
            modelBuilder.Entity<bookmark>().Property(x => x.nameid).HasColumnName("nameid");

            modelBuilder.Entity<findingmovie>().HasNoKey();
            modelBuilder.Entity<findingmovie>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<findingmovie>().Property(x => x.originaltitle).HasColumnName("originaltitle");

        }
    }


}