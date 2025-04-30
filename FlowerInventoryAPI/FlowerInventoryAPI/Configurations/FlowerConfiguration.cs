using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerInventoryAPI.Configurations
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.HasKey(f=>f.FlowerId);

            builder.Property(f => f.Name).IsRequired();

            builder.Property(f => f.Name).HasMaxLength(255);

            builder.Property(f=>f.Price).IsRequired();

            builder.Property(f => f.Price).HasPrecision(18, 2);

            builder.HasOne(f => f.Category)
                .WithMany(c => c.Flowers)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
