using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //properties validations
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();

            //relationships
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(f => f.ProductBrandId);
            builder.HasOne(b => b.ProductType).WithMany().HasForeignKey(f => f.ProductTypeId);
        }       
    }
}
