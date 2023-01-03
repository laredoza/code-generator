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
using Microsoft.AspNetCore.Http;
using Infrastructure.Core.Extensions;
using System.Reflection;
using CodeGenerator.Infrastructure.Core.Entities;

namespace CodeGenerator.Infrastructure.Data.Context.SqlServer
{
	public partial class FullContext : DbContext, IUnitOfWork
	{
		#region Constants 
		public const string DEFAULT_SCHEMA = "dbo";
		#endregion
		#region Fields
		readonly IHttpContextAccessor _httpContextAccessor;
		readonly string _user;
		#endregion
		#region Constructors
		public FullContext(IHttpContextAccessor httpContextAccessor, DbContextOptions<FullContext> options) :
			base(options)
		{
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext?.User?.GetEmail() ?? _httpContextAccessor.HttpContext?.User?.GetClient() ?? "System";
		}
		#endregion
		#region DbSets 
		
		public DbSet<BankAccount> BankAccount { get; set; }
		
		public DbSet<Customer> Customer { get; set; }
		
		public DbSet<Country> Country { get; set; }
		
		public DbSet<BankTransfers> BankTransfers { get; set; }
		
		public DbSet<Book> Book { get; set; }
		
		public DbSet<Product> Product { get; set; }
		
		public DbSet<Order> Order { get; set; }
		
		public DbSet<OrderDetails> OrderDetails { get; set; }
		
		public DbSet<Software> Software { get; set; }
		
    		#endregion
		#region Properties
    		protected override void OnModelCreating(ModelBuilder modelBuilder)
    		{
			modelBuilder.HasDefaultSchema(FullContext.DEFAULT_SCHEMA);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		#endregion
	}
}