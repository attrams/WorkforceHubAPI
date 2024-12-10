using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkforceHubAPI.WebAPI;
using WorkforceHubAPI.WebAPI.Extensions;
using WorkforceHubAPI.WebAPI.Formatters;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddSimpleConsole().AddDebug();

// Add services to the container.
// configure serilog
builder.Host.UseSerilog(
    (context, configuration) =>
    {
        configuration.MinimumLevel.Is(Serilog.Events.LogEventLevel.Information);
        configuration.ReadFrom.Configuration(context.Configuration);
        configuration.Enrich.WithThreadId();
        configuration.Enrich.WithMachineName();
        configuration.WriteTo.File(
            "./logs/log-.txt",
            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
            rollingInterval: RollingInterval.Day,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u}] [{MachineName} #{ThreadId}] {Message:lj}{NewLine}{Exception}"
        );
    },
    writeToProviders: true
);

builder.Services.ConfigureCors();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureRepositoryManager();

builder.Services.ConfigureServiceManager();

// configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configure the ExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// enable custom response for controllers
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Register the custom validation filter attribute in the dependency injection container.
builder.Services.AddScoped<ValidationFilterAttribute>();

// Configures the application's controller services and ensures that the controllers from the specified
// assembly (via the AssemblyReference class in WorkforceHubAPI.WebAPI.Presentation project) are included
// in the application's controller discovery process.
// Adds XML and CSV serialization support, allowing the API to return responses in XML or CSV format if specified in the
// 'Accept' header of the request.
builder
    .Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
        config.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
        // config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
    })
    .AddXmlDataContractSerializerFormatters()
    .AddCustomCSVFormatter()
    .AddApplicationPart(typeof(WorkforceHubAPI.WebAPI.Presentation.AssemblyReference).Assembly);

builder.Services.ConfigureVersioning();

builder.Services.ConfigureOutputCaching();

builder.Services.ConfigureRateLimitingOptions();

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.ConfigureSwagger();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseExceptionHandler(options => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

app.UseRateLimiter();

app.UseCors("CorsPolicy");

app.UseOutputCache();

// Redirect root URL to Swagger UI.
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkforceHub API v1");
    setupAction.SwaggerEndpoint("/swagger/v2/swagger.json", "WorkforceHub API v2");
});

app.MapControllers();

app.Run();