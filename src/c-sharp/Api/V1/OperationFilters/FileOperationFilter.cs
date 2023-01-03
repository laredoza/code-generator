using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CodeGenerator.Api.V1.OperationFilters
{
    public class FileOperationFilter : IOperationFilter  
    {  
        public void Apply(OpenApiOperation operation, OperationFilterContext context)  
        {  
            var fileUploadMime = "multipart/form-data";  
            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))  
                return;  
  
            var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
            var otherParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType != typeof(IFormFile));

            // Get reference to initial OpenAPI schema dictionary
            var oldDictionary = operation.RequestBody.Content[fileUploadMime].Schema.Properties;
            
            // Create a new OpenAPI schema dictionary
            var dictionary = new Dictionary<string, OpenApiSchema>();
            
            // Replace form file schemas with binary so we can upload files
            foreach (var parameterInfo in fileParams)
            {
                dictionary.Add(parameterInfo.Name, new OpenApiSchema()
                {
                    Type = "string",
                    Format = "binary"
                });
            }
            
            // Re-add existing parameter schemas to the new dictionary
            foreach (var parameterInfo in otherParams)
            {
                if (oldDictionary.ContainsKey(parameterInfo.Name))
                {
                    dictionary.Add(parameterInfo.Name, oldDictionary[parameterInfo.Name]);
                }
            }

            operation.RequestBody.Content[fileUploadMime].Schema.Properties = dictionary;
        }  
    }   
}