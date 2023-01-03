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
	public partial class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
        	{
			builder.ToTable("Order", "Dbo");

			builder.HasKey(t => t.OrderId);

			builder.Property(t => t.OrderId).IsRequired();
			builder.Property(t => t.CustomerId).IsRequired(false);
			builder.Property(t => t.OrderDate).IsRequired(false);
			builder.Property(t => t.DeliveryDate).IsRequired(false);
			builder.Property(t => t.ShippingName).HasMaxLength(50);
			builder.Property(t => t.ShippingName).IsRequired(false);
			builder.Property(t => t.ShippingAddress).HasMaxLength(50);
			builder.Property(t => t.ShippingAddress).IsRequired(false);
			builder.Property(t => t.ShippingCity).HasMaxLength(50);
			builder.Property(t => t.ShippingCity).IsRequired(false);
			builder.Property(t => t.ShippingZip).HasMaxLength(50);
			builder.Property(t => t.ShippingZip).IsRequired(false);


			builder.HasIndex(t => t.CustomerId)
			       .HasDatabaseName("IX_CustomerId");

			builder.Property(t => t.OrderId).HasColumnOrder(1);
			builder.Property(t => t.CustomerId).HasColumnOrder(2);
			builder.Property(t => t.OrderDate).HasColumnOrder(3);
			builder.Property(t => t.DeliveryDate).HasColumnOrder(4);
			builder.Property(t => t.ShippingName).HasColumnOrder(5);
			builder.Property(t => t.ShippingAddress).HasColumnOrder(6);
			builder.Property(t => t.ShippingCity).HasColumnOrder(7);
			builder.Property(t => t.ShippingZip).HasColumnOrder(8);

			builder.HasOne<Customer>(s => s.Customer) // 1
			      .WithMany(s => s.Orders)
			      .HasForeignKey(s => s.CustomerId)
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<OrderDetails>(s => s.OrderDetailss)
			      .WithOne(t => t.Order) // 2
			      .HasForeignKey("FK_OrderDetails_Order_OrderId_child")
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}