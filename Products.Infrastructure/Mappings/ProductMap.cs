using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntityModel>
    {
        public void Configure(EntityTypeBuilder<ProductEntityModel> builder)
        {
            builder.ToTable("product", "dbo");

            builder.HasKey(x => x.IdProduct);

            builder.Property(x => x.IdProduct)
                .HasColumnName("idproduct");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.OutOfStock)
                .HasColumnName("outOfStock");
        }
    }
}
