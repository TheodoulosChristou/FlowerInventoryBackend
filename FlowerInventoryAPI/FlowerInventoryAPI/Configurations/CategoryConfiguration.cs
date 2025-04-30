using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerInventoryAPI.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.CategoryId);

            builder.Property(c => c.CategoryName).IsRequired();

            builder.Property(c=>c.CategoryName).HasMaxLength(255);
        }
    }
}
