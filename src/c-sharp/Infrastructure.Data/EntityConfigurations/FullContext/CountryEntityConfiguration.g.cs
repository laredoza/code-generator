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
	public partial class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> builder)
        	{
			builder.ToTable("Country", "Dbo");

			builder.HasKey(t => t.CountryId);

			builder.Property(t => t.CountryId).IsRequired();
			builder.Property(t => t.CountryName).HasMaxLength(100);
			builder.Property(t => t.CountryName).IsRequired(false);



			builder.Property(t => t.CountryId).HasColumnOrder(1);
			builder.Property(t => t.CountryName).HasColumnOrder(2);

			builder.HasMany<Customer>(s => s.Customers)
			      .WithOne(u => u.Country) // 3
			      .HasForeignKey("FK_Customer_Country_CountryId_child")
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}