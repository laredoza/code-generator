// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	#region Usings
	using Microsoft.Extensions.DependencyInjection;
	using global::CodeGenerator.CodeGenerator.Api.V1.Services.FullContext;
	#endregion

	/// <summary>
	///     The ApplicationServicesExtension.
	/// </summary>
	public static class ApplicationServicesExtension
	{
		#region Public Methods And Operators

		public static void ConfigureApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IBankAccountService, BankAccountService>();
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddScoped<IBankTransfersService, BankTransfersService>();
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IOrderDetailsService, OrderDetailsService>();
			services.AddScoped<ISoftwareService, SoftwareService>();
		}

		#endregion
	}
}