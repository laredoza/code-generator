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
	public partial class BookEntityConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
        	{
			builder.ToTable("Book", "Dbo");

			builder.HasKey(t => t.ProductId);

			builder.Property(t => t.ProductId).IsRequired();
			builder.Property(t => t.Publisher).HasMaxLength(200);
			builder.Property(t => t.Publisher).IsRequired();



			builder.Property(t => t.ProductId).HasColumnOrder(1);
			builder.Property(t => t.Publisher).HasColumnOrder(2);

			builder.HasOne<Product>(s => s.Product) // 1
			      .WithOne(v => v.Book) // 4
			      .OnDelete(DeleteBehavior.Restrict);
		}
	}
}