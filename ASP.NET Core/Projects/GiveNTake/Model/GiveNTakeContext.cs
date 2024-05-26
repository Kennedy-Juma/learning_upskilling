using Microsoft.EntityFrameworkCore;

namespace GiveNTake.Model
{
    public class GiveNTakeContext : DbContext
    {
        public GiveNTakeContext(DbContextOptions<GiveNTakeContext> options): base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(sub => sub.ParentCategory)
                .WithMany(c => c.Subcategories)
                .IsRequired(false);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .IsRequired();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

    }
}