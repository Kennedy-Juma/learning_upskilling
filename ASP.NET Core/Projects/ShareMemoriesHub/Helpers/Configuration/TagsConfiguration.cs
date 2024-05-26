using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShareMemoriesHub.Models.Tags;
using ShareMemoriesHub.Models.Memories;

namespace ShareMemoriesHub.Helpers.Configuration
{
        public class TagsConfiguration : IEntityTypeConfiguration<Tag>
        {
            public void Configure(EntityTypeBuilder<Tag> builder)
            {
            builder.HasKey(t => t.Id);
                builder.HasOne(t => t.Memory)
                        .WithOne()
                        .HasForeignKey<Tag>(t => t.MemoryId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
            builder.Property(t => t.Id)
                .HasColumnType("varchar")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.MemoryId)
                .HasColumnType("varchar");
        }
        }
}
