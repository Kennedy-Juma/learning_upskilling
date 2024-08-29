using DatingApp.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebAPI.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
