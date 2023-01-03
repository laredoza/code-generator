namespace CodeGenerator.Api.V1.Extensions
{
	#region Usings

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	#endregion

	/// <summary>
	///     The ContextExtension.
	/// </summary>
	public static class ContextExtension
	{
		#region Public Methods And Operators

		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			// services.AddDbContext<FullContext>(options =>
			// {
			// 	options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
		    	// 	{
			//     		sqlOptions.MigrationsAssembly("Infrastructure.Data");
			//     		sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", FullContext.DEFAULT_SCHEMA);
		    	// 	});
			// });
		}


		#endregion
	}
}