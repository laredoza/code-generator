using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace CodeGenerator.Api.Infrastructure.Swagger
{
    /// <summary>
    /// Defines Swagger related service extension methods.
    /// </summary>
    public static class ServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
                {
                    // Add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // Use method name as operationId
                    options.CustomOperationIds(apiDesc =>
                    {
                        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                    });
 
                    // Include Descriptions from XML Comments
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(filePath);

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "In the value text box type \"Bearer \" and then paste the token.",
                        Name = "Authorization",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header ,
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference 
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer" 
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header

                            }, new List<string>() }
                    });


                }
            );

            return services;
        }
    }
}