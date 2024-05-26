using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareMemoriesHub.Models.Images;

namespace ShareMemoriesHub.Helpers.Configuration
{
    public class ImagesConfiguration:IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.Memory)
                    .WithOne()
                    .HasForeignKey<Image>(i => i.MemoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            builder.Property(i => i.Id)
                .HasColumnType("varchar")
                .ValueGeneratedOnAdd();
            builder.Property(i => i.MemoryId)
                .HasColumnType("varchar");
        }
    }
}
