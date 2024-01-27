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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer();
        }
    }
}
