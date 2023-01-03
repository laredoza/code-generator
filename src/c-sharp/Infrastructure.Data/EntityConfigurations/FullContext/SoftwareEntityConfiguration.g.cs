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
	public partial class SoftwareEntityConfiguration : IEntityTypeConfiguration<Software>
	{
		public void Configure(EntityTypeBuilder<Software> builder)
        	{
			builder.ToTable("Software", "Dbo");

			builder.HasKey(t => t.ProductId);

			builder.Property(t => t.ProductId).IsRequired();
			builder.Property(t => t.LicenseCode).HasMaxLength(200);
			builder.Property(t => t.LicenseCode).IsRequired();



			builder.Property(t => t.ProductId).HasColumnOrder(1);
			builder.Property(t => t.LicenseCode).HasColumnOrder(2);

			builder.HasOne<Product>(s => s.Product) // 1
			      .WithOne(v => v.Software) // 4
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}