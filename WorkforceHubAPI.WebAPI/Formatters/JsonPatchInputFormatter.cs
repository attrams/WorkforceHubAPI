using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace WorkforceHubAPI.WebAPI.Formatters;

/// <summary>
/// Provides a method to retrieve the <see cref="NewtonsoftJsonPatchInputFormatter"/> for processing
/// JSON PATCH requests using Newtonsoft.Json.
/// </summary>
/// <remarks>
/// This class is adapted from the offical ASP.NET Core documentation. For more information, visit: 
/// <a href="https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-9.0">JsonPatch in ASP.NET Core web API</a>
/// </remarks>
public static class JsonPatchInputFormatter
{
    /// <summary>
    /// Retrieves an instance of <see cref="NewtonsoftJsonPatchInputFormatter"/> configured with the default
    /// ASP.NET Core MVC settings.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="NewtonsoftJsonPatchInputFormatter"/> configured for JSON PATCH requests.
    /// </returns>
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}