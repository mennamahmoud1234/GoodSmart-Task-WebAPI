using GoodSmart_Task.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodSmart_Task.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(128).IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal (18,2)");
            
        }
    }
}
