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
	public partial class BankAccountEntityConfiguration : IEntityTypeConfiguration<BankAccount>
	{
		public void Configure(EntityTypeBuilder<BankAccount> builder)
        	{
			builder.ToTable("BankAccount", "Dbo");

			builder.HasKey(t => t.BankAccountId);

			builder.Property(t => t.BankAccountId).IsRequired();
			builder.Property(t => t.BankAccountNumber).HasMaxLength(10);
			builder.Property(t => t.BankAccountNumber).IsRequired();
			builder.Property(t => t.Balance).IsRequired();builder.Property(t => t.Balance).HasPrecision(19,4);
			builder.Property(t => t.CustomerId).IsRequired(false);
			builder.Property(t => t.Locked).IsRequired();


			builder.HasIndex(t => t.CustomerId)
			       .HasDatabaseName("IX_CustomerId1");

			builder.Property(t => t.BankAccountId).HasColumnOrder(1);
			builder.Property(t => t.BankAccountNumber).HasColumnOrder(2);
			builder.Property(t => t.Balance).HasColumnOrder(3);
			builder.Property(t => t.CustomerId).HasColumnOrder(4);
			builder.Property(t => t.Locked).HasColumnOrder(5);

			builder.HasOne<Customer>(s => s.Customer) // 1
			      .WithMany(s => s.BankAccounts)
			      .HasForeignKey(s => s.CustomerId)
			      .OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<BankTransfers>(s => s.BankTransferss)
			      .WithOne(t => t.BankAccount) // 2
			      // .HasForeignKey("FK_BankTransfers_BankAccount_ToBankAccountId_child")
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}