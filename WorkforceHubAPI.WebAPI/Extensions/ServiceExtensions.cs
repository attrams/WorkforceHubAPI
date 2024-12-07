using Microsoft.EntityFrameworkCore;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.LoggerService;
using WorkforceHubAPI.Repository;
using WorkforceHubAPI.Service;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.WebAPI.Formatters;
using Asp.Versioning;
using WorkforceHubAPI.WebAPI.Presentation.Controllers;
using System.Threading.RateLimiting;
using WorkforceHubAPI.Entities.ErrorModel;

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
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader()
            );
        });

    /// <summary>
    /// Configures and registers the logger service to the dependency injection container.
    /// This method adds the <see cref="ILoggerManager"/> interface and binds it to the <see cref="LoggerManager"/> implementation.
    /// The <see cref="LoggerManager"/> will be used throughout the application for logging purposes.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the logger service will be added.</param>
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    /// <summary>
    /// Configures the repository manager service for dependency injection.
    /// Registers <see cref="RepositoryManager"/> as the implementation for <see cref="IRepositoryManager"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> used for dependency injection.</param>
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    /// <summary>
    /// Configures the service manager for dependency injection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the service manager will be added.</param>
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    /// <summary>
    /// Configures the SQL Server context in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which the database context will be added.</param>
    /// <param name="configuration">The application configuration for accessing the database connection string.</param>
    public static void ConfigureSqlContext(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

    /// <summary>
    /// Configures the custom CSV output formatter by adding it to the MVC pipeline.
    /// </summary>
    /// <param name="builder">The <see cref="IMvcBuilder"/> instance to configure MVC options.</param>
    /// <returns>The updated <see cref="IMvcBuilder"/> instance with the CSV output formatter added.</returns>
    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) => builder.AddMvcOptions(
        config => config.OutputFormatters.Add(new CsvOutputFormatter())
    );

    /// <summary>
    /// Configures API versioning for the application by defining default and supported API versions.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
        }).AddMvc(options =>
        {
            options.Conventions.Controller<CompanyController>().HasApiVersion(new ApiVersion(1, 0));
            options.Conventions.Controller<EmployeeController>().HasApiVersion(new ApiVersion(1, 0));
            options.Conventions.Controller<CompanyV2Controller>().HasDeprecatedApiVersion(new ApiVersion(2, 0));
        });
    }

    /// <summary>
    /// Configures response caching for the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
    public static void ConfigureOutputCaching(this IServiceCollection services)
    {
        services.AddOutputCache(options =>
        {
            // options.AddBasePolicy(basePolicy => basePolicy.Expire(TimeSpan.FromSeconds(10)));
            options.AddPolicy("120SecondsDuration", policy => policy.Expire(TimeSpan.FromSeconds(120)));
        });
    }

    /// <summary>
    /// Configures rate limiting options for the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the rate limiter configuration to.</param>
    public static void ConfigureRateLimitingOptions(this IServiceCollection services)
    {
        // Add a global rate limiter with a fixed window policy. 
        services.AddRateLimiter(options =>
        {
            // Define a global limiter with a maximum of 10 requests per minute
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter", partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 20,
                    QueueLimit = 0,
                    Window = TimeSpan.FromMinutes(1)
                })
            );

            // Handle requests that exceed the rate limit.
            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsJsonAsync(
                        new ErrorDetails
                        {
                            StatusCode = context.HttpContext.Response.StatusCode,
                            Message = $"Too many requests. Please try again after {retryAfter.TotalSeconds} second(s)."
                        },
                        token
                    );
                }
                else
                {
                    await context.HttpContext.Response.WriteAsJsonAsync(
                        new ErrorDetails
                        {
                            StatusCode = context.HttpContext.Response.StatusCode,
                            Message = "Too many requests. Please try again later."
                        },
                        token
                    );
                }
            };
        });
    }
}
