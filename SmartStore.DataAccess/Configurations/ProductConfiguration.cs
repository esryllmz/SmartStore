using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Models.Entities;

namespace SmartStore.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ProductId");
            builder.Property(p => p.Name)
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasColumnName("Description")
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnName("Price")
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CategoryId).HasColumnName("CategoryId");

            builder.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedTime");

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
