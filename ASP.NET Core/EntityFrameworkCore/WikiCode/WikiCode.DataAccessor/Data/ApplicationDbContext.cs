using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiCode.Models.Models;

namespace WikiCode.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WikiCode;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
         builder.Entity<Book>().Property(u=>u.Price).HasPrecision(10,5);
         
            //seed book data
            var bookList = new Book[]
            {
               new Book{BookId = 1, Title = "Book1", ISBN = "12345", Price = 10.50m },
               new Book{BookId = 2, Title = "Book2", ISBN = "12345", Price = 9.0m },
               new Book{BookId = 3, Title = "Book3", ISBN = "123456", Price = 40.5m },
               new Book{BookId = 4, Title = "Book4", ISBN = "1234567", Price = 30.7m },
               new Book{BookId = 5, Title = "Book5", ISBN = "1234578", Price = 2.5m }
                
            };

            builder.Entity<Book>().HasData(bookList);


        }
    }
}
