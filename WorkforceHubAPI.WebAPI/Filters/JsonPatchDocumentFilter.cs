using System.Net.Mime;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WorkforceHubAPI.WebAPI.Filters;

/// <summary>
/// This class implements the <see cref="IOperationFilter"/> interface to customize the Swagger UI for PATCH requests.
/// It specifically adds a JSON Patch example to the Swagger documentation for operations that accept 
/// the "application/json-patch+json" content type.
/// </summary>
public class JsonPatchDocumentFilter : IOperationFilter
{
    /// <summary>
    /// Applies custom modifications to the swagger operation for PATCH requests, specifically adding
    /// an example for the JSON Patch request body.
    /// </summary>
    /// <param name="operation">The <see cref="OpenApiOperation"/> representing the swagger operation being processed.</param>
    /// <param name="context">The context for the operation filter, containing information about the API description.</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Check if the HTTP method is PATCH, if not, do not apply any changes.
        if (!context.ApiDescription.HttpMethod!.Equals("patch", StringComparison.InvariantCultureIgnoreCase))
        {
            return;
        }

        // Ensure that the operation contains a request body of type "application/json-patch+json".
        if (operation.RequestBody != null && operation.RequestBody.Content.ContainsKey(MediaTypeNames.Application.JsonPatch))
        {
            // Add the example to the request body schema for JSON Patch.
            var patchBodyRequest = operation.RequestBody.Content[MediaTypeNames.Application.JsonPatch];

            if (patchBodyRequest != null)
            {
                patchBodyRequest.Examples = new Dictionary<string, OpenApiExample>
                {
                    {
                        MediaTypeNames.Application.JsonPatch, new OpenApiExample
                        {
                            Value = new OpenApiArray
                            {
                                new OpenApiObject
                                {
                                    { "op", new OpenApiString("replace") },
                                    { "path", new OpenApiString("/name") },
                                    { "value", new OpenApiString("New Employee Name") }
                                },
                                new OpenApiObject
                                {
                                    { "op", new OpenApiString("remove") },
                                    { "path", new OpenApiString("/age") }
                                }
                            }
                        }
                    }
                };
            }

        }

    }
}