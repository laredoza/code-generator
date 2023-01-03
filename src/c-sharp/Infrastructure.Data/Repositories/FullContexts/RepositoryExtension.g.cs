// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
namespace CodeGenerator.Infrastructure.Data.Repositories.FullContexts
{
	#region Usings

	using Microsoft.Extensions.DependencyInjection;
	using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
	using CodeGenerator.Infrastructure.Data.Repositories.FullContexts;

	#endregion

	/// <summary>
	///     The RepositoryExtension.
	/// </summary>
	public static class RepositoryExtension
	{
		#region Public Methods And Operators

		public static void ConfiguresRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBankAccountRepository, BankAccountRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<IBankTransfersRepository, BankTransfersRepository>();
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
			services.AddScoped<ISoftwareRepository, SoftwareRepository>();
		}

		#endregion
	}
}