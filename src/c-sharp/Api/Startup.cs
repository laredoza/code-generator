using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using CodeGenerator.Api.Infrastructure.Swagger;
using CodeGenerator.Api.V1.Extensions;
using Infrastructure.Infrastructure.Data.Repositories;
using AutoMapper;
using Infrastructure.Core.SharedKernel;
using CodeGenerator.Infrastructure.Data.Repositories.FullContexts;
using CodeGenerator.CodeGenerator.Api.V1.Services.FullContext;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace CodeGenerator.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			ConfigureMvc(services);
			ConfigureDbContext(services);
			ConfigureAuthentication(services);
			ConfigureAuthorization(services);
			ConfigureHealthChecks(services);
			ConfigureAutoMapper(services);
			ConfigureIntegrations(services);
			ConfigureApplicationServices(services);

			services.AddApplicationInsightsTelemetry(Configuration)
			    .AddSwaggerDocumentation(Configuration)
			    .AddResponseCompression()
			    .AddOptions();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
		{
			app.UseExceptionHandler("/error");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseResponseCompression();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			    {
				    options.DisplayOperationId();
				    // build a swagger endpoint for each discovered API version
				    foreach (var description in provider.ApiVersionDescriptions)
				    {
					    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
				    }
				    options.RoutePrefix = string.Empty;
			    }
			);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHealthChecks("/health", new HealthCheckOptions()
				{
					AllowCachingResponses = false
				});
			});
		}

		static void ConfigureMvc(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
			})
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

			})
			.AddNewtonsoftJson(options =>
			    {
				    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			    }
			);

			services.AddMvcCore().AddApiExplorer();

			services.AddApiVersioning(options =>
			{
				// Reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
				options.ReportApiVersions = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
			})
			.AddVersionedApiExplorer(options =>
			{
				// Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
				// Note: the specified format code will format the version as "'v'major[.minor][-status]"
				options.GroupNameFormat = "'v'VVV";
			});
		}

		void ConfigureDbContext(IServiceCollection services)
		{
			services.ConfigureDbContext(Configuration);
		}

		void ConfigureAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				Configuration.Bind("Authentication", options)
			    );
		}

		static void ConfigureAuthorization(IServiceCollection services)
		{
			services.AddControllers(config =>
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});

			services.AddAuthorization(options =>
			{
				// administrators can perform all actions.
				options.AddPolicy("IsAdmin", policy => policy.RequireClaim("is_admin"));
			});
		}

		static void ConfigureHealthChecks(IServiceCollection services)
		{
			var hcBuilder = services.AddHealthChecks();

			hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());
			// hcBuilder.AddDbContextCheck<EfCoreContext>();
		}

		static void ConfigureAutoMapper(IServiceCollection services)
		{
			// services.AddAutoMapper(typeof(Startup));
		}

		static void ConfigureIntegrations(IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			// services.ConfiguresRepositories();
		}

		public void ConfigureApplicationServices(IServiceCollection services)
		{
			// services.ConfigureApplicationServices();
		}
	}
}