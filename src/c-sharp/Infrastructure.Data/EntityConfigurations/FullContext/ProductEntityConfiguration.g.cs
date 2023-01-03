// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;
using CodeGenerator.Infrastructure.Core.Entities;

namespace CodeGenerator.Infrastructure.Data.EntityConfigurations.FullContext
{
	public partial class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
        	{
			builder.ToTable("Product", "Dbo");

			builder.HasKey(t => t.ProductId);

			builder.Property(t => t.ProductId).IsRequired();
			builder.Property(t => t.ProductDescription).HasMaxLength(100);
			builder.Property(t => t.ProductDescription).IsRequired(false);
			builder.Property(t => t.UnitPrice).IsRequired(false);builder.Property(t => t.UnitPrice).HasPrecision(19,4);
			builder.Property(t => t.AmountInStock).IsRequired(false);



			builder.Property(t => t.ProductId).HasColumnOrder(1);
			builder.Property(t => t.ProductDescription).HasColumnOrder(2);
			builder.Property(t => t.UnitPrice).HasColumnOrder(3);
			builder.Property(t => t.AmountInStock).HasColumnOrder(4);

			builder.HasOne<Book>(s => s.Book) // 1
			      .WithOne(t => t.Product) // 2
			      // .HasForeignKey("FK_Book_Product_ProductId_child")
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<OrderDetails>(s => s.OrderDetailss)
			      .WithOne(t => t.Product) // 2
			      // .HasForeignKey("FK_OrderDetails_Product_ProductId_child")
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasOne<Software>(s => s.Software) // 1
			      .WithOne(t => t.Product) // 2
			      // .HasForeignKey("FK_Software_Product_ProductId_child")
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}