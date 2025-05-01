using System.Collections;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2);
            builder.Property(p => p.Description).HasMaxLength(500);
            
            builder.HasData(
                new Products
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    Price = 10.00m
                },
                new Products
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    Price = 20.00m
                },
                new Products
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description for Product 3",
                    Price = 30.00m
                }
            );
        }
    }
}