using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.LoggerService;

namespace WorkforceHubAPI.WebAPI.Extensions;

/// <summary>
/// Provides extension methods for configuring application services.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Configures Cross-Origin Resource Sharing (CORS) for the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the CORS service is added.</param>
    /// <remarks>
    /// This method registers a CORS policy named "CorsPolicy" that allows:
    /// <list type="bullet">
    /// <item><description>Any origin</description></item>
    /// <item><description>Any HTTP method</description></item>
    /// <item><description>Any HTTP header</description></item>
    /// </list>
    /// <para>
    /// This is useful for enabling communication between the API and client applications hosted on different domains.
    /// However, it is recommended to restrict origins and headers in production environments for security.
    /// </para>
    /// </remarks>
    /// <example>
    /// Example usage in <c>Program.cs</c>
    /// <code>
    /// builder.Services.ConfigureCors();
    /// app.UseCors("CorsPolicy")
    /// </code>
    /// </example>
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyHeader()
        );
    });

    /// <summary>
    /// Configures and registers the logger service to the dependency injection container.
    /// This method adds the <see cref="ILoggerManager"/> interface and binds it to the <see cref="LoggerManager"/> implementation.
    /// The <see cref="LoggerManager"/> will be used throughout the application for logging purposes.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the logger service will be added.</param>
    public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
}