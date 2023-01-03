namespace CodeGenerator.Api.V1.Extensions
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
			// services.AddScoped<IPatientService, PatientService>();
			// services.AddScoped<IVisitService, VisitService>();
		}

		#endregion
	}
}