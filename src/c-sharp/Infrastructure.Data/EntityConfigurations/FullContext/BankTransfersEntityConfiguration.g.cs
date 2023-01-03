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
	public partial class BankTransfersEntityConfiguration : IEntityTypeConfiguration<BankTransfers>
	{
		public void Configure(EntityTypeBuilder<BankTransfers> builder)
        	{
			builder.ToTable("BankTransfers", "Dbo");

			builder.HasKey(t => t.BankTransferId);

			builder.Property(t => t.BankTransferId).IsRequired();
			builder.Property(t => t.FromBankAccountId).IsRequired();
			builder.Property(t => t.ToBankAccountId).IsRequired();
			builder.Property(t => t.Amount).IsRequired();builder.Property(t => t.Amount).HasPrecision(18,2);
			builder.Property(t => t.TransferDate).IsRequired();


			builder.HasIndex(t => t.ToBankAccountId)
			       .HasDatabaseName("IX_ToBankAccountId");

			builder.Property(t => t.BankTransferId).HasColumnOrder(1);
			builder.Property(t => t.FromBankAccountId).HasColumnOrder(2);
			builder.Property(t => t.ToBankAccountId).HasColumnOrder(3);
			builder.Property(t => t.Amount).HasColumnOrder(4);
			builder.Property(t => t.TransferDate).HasColumnOrder(5);

			builder.HasOne<BankAccount>(s => s.BankAccount) // 1
			      .WithMany(s => s.BankTransferss)
			      .HasForeignKey(s => s.ToBankAccountId)
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}