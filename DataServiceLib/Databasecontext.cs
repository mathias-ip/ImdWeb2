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
        internal object structuredSearch;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql("host=localhost;db=imdb;uid=postgres;pwd=191191Ippe");
        }

        internal static object FromSql(string v)
        {
            throw new NotImplementedException();
        }

        public DbSet<SearchResult> SearchResults { get; set; }

        public DbSet<structuredStringSearch> structuredStringSearch { get; set; }

        public DbSet<Title> title { get; set; }
       // public object SearchResults { get; internal set; }

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

            /*    modelBuilder.Entity<Product>().ToTable("products");
                modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
               // modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
               // modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");

                modelBuilder.Entity<Orders>().ToTable("orders");
                modelBuilder.Entity<Orders>().Property(x => x.Id).HasColumnName("orderid");
                modelBuilder.Entity<Orders>().Property(x => x.orderdate).HasColumnName("orderdate");
                modelBuilder.Entity<Orders>().Property(x => x.shipname).HasColumnName("shipname");
                modelBuilder.Entity<Orders>().Property(x => x.shipcity).HasColumnName("shipcity");
                // modelBuilder.Entity<Orders>().Property(x => x.date).HasColumnName("orderdate");
                //modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");
             */

            /*  modelBuilder.Entity<Orderdetails>().ToTable("orderdetails");
              modelBuilder.Entity<Orderdetails>().Property(x => x.productid).HasColumnName("Íd");
              modelBuilder.Entity<Orderdetails>().Property(x => x.productname).HasColumnName("productname");
              modelBuilder.Entity<Orderdetails>().Property(x => x.unitprice).HasColumnName("unitprice");
              modelBuilder.Entity<Orderdetails>().Property(x => x.quantity).HasColumnName("quantity"); */
        }
    }


}