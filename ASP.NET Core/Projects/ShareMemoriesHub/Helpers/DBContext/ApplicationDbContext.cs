using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareMemoriesHub.Helpers.Configuration;
using ShareMemoriesHub.Models.Images;
using ShareMemoriesHub.Models.Memories;
using ShareMemoriesHub.Models.Tags;

namespace ShareMemoriesHub.Helpers.DBContext
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)

        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MemoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagsConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesConfiguration());
        }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
