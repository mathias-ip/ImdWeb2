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
        //Mathias er en nar
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

        public DbSet<Title> title { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Title>().ToTable("title");
            modelBuilder.Entity<Title>().Property(x => x.titleid).HasColumnName("titleid");
            modelBuilder.Entity<Title>().Property(x => x.primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Title>().Property(x => x.titletype).HasColumnName("titletype");

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