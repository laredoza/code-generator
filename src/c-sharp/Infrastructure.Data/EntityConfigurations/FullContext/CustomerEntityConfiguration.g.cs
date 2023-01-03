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
	public partial class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
        	{
			builder.ToTable("Customer", "Dbo");

			builder.HasKey(t => t.CustomerId);

			builder.Property(t => t.CustomerId).IsRequired();
			builder.Property(t => t.CustomerCode).HasMaxLength(5);
			builder.Property(t => t.CustomerCode).IsRequired();
			builder.Property(t => t.CompanyName).HasMaxLength(50);
			builder.Property(t => t.CompanyName).IsRequired();
			builder.Property(t => t.ContactName).HasMaxLength(50);
			builder.Property(t => t.ContactName).IsRequired(false);
			builder.Property(t => t.ContactTitle).HasMaxLength(50);
			builder.Property(t => t.ContactTitle).IsRequired(false);
			builder.Property(t => t.Address).HasMaxLength(50);
			builder.Property(t => t.Address).IsRequired(false);
			builder.Property(t => t.City).HasMaxLength(20);
			builder.Property(t => t.City).IsRequired(false);
			builder.Property(t => t.PostalCode).HasMaxLength(10);
			builder.Property(t => t.PostalCode).IsRequired(false);
			builder.Property(t => t.Telephone).HasMaxLength(50);
			builder.Property(t => t.Telephone).IsRequired(false);
			builder.Property(t => t.Fax).HasMaxLength(50);
			builder.Property(t => t.Fax).IsRequired(false);
			builder.Property(t => t.CountryId).IsRequired(false);
			builder.Property(t => t.Photo).HasMaxLength(255);
			builder.Property(t => t.Photo).IsRequired(false);
			builder.Property(t => t.IsEnabled).IsRequired();


			builder.HasIndex(t => t.CountryId)
			       .HasDatabaseName("IX_CountryId");

			builder.Property(t => t.CustomerId).HasColumnOrder(1);
			builder.Property(t => t.CustomerCode).HasColumnOrder(2);
			builder.Property(t => t.CompanyName).HasColumnOrder(3);
			builder.Property(t => t.ContactName).HasColumnOrder(4);
			builder.Property(t => t.ContactTitle).HasColumnOrder(5);
			builder.Property(t => t.Address).HasColumnOrder(6);
			builder.Property(t => t.City).HasColumnOrder(7);
			builder.Property(t => t.PostalCode).HasColumnOrder(8);
			builder.Property(t => t.Telephone).HasColumnOrder(9);
			builder.Property(t => t.Fax).HasColumnOrder(10);
			builder.Property(t => t.CountryId).HasColumnOrder(11);
			builder.Property(t => t.Photo).HasColumnOrder(12);
			builder.Property(t => t.IsEnabled).HasColumnOrder(13);

			builder.HasOne<Country>(s => s.Country) // 1
			      .WithMany(s => s.Customers)
			      .HasForeignKey(s => s.CountryId)
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<BankAccount>(s => s.BankAccounts)
			      .WithOne(u => u.Customer) // 3
			      .HasForeignKey("FK_BankAccount_Customer_CustomerId_child")
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<Order>(s => s.Orders)
			      .WithOne(u => u.Customer) // 3
			      .HasForeignKey("FK_Order_Customer_CustomerId_child")
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}