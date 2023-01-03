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
	public partial class OrderDetailsEntityConfiguration : IEntityTypeConfiguration<OrderDetails>
	{
		public void Configure(EntityTypeBuilder<OrderDetails> builder)
        	{
			builder.ToTable("OrderDetails", "Dbo");

			builder.HasKey(t => t.OrderDetailsId);

			builder.Property(t => t.OrderDetailsId).IsRequired();
			builder.Property(t => t.OrderId).IsRequired();
			builder.Property(t => t.ProductId).IsRequired();
			builder.Property(t => t.UnitPrice).IsRequired(false);builder.Property(t => t.UnitPrice).HasPrecision(19,4);
			builder.Property(t => t.Amount).IsRequired(false);
			builder.Property(t => t.Discount).IsRequired(false);


			builder.HasIndex(t => t.ProductId)
			       .HasDatabaseName("IX_ProductId2");
			builder.HasIndex(t => t.OrderId)
			       .HasDatabaseName("IX_OrderId1");

			builder.Property(t => t.OrderDetailsId).HasColumnOrder(1);
			builder.Property(t => t.OrderId).HasColumnOrder(2);
			builder.Property(t => t.ProductId).HasColumnOrder(3);
			builder.Property(t => t.UnitPrice).HasColumnOrder(4);
			builder.Property(t => t.Amount).HasColumnOrder(5);
			builder.Property(t => t.Discount).HasColumnOrder(6);

			builder.HasOne<Order>(s => s.Order) // 1
			      .WithMany(s => s.OrderDetailss)
			      .HasForeignKey(s => s.OrderId)
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasOne<Product>(s => s.Product) // 1
			      .WithMany(s => s.OrderDetailss)
			      .HasForeignKey(s => s.ProductId)
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}