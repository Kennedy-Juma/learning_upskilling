using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareMemoriesHub.Models.Memories;
using System.Reflection.Emit;

namespace ShareMemoriesHub.Helpers.Configuration
{
    public class MemoryConfiguration : IEntityTypeConfiguration<Memory>
    {
        public void Configure(EntityTypeBuilder<Memory> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.IdentityUser)
                    .WithMany()
                    .HasForeignKey(m => m.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            builder.Property(m => m.Id)
                .HasColumnType("varchar")
                .ValueGeneratedOnAdd();
        }
    }
}
