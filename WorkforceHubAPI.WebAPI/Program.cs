using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.WebAPI;
using WorkforceHubAPI.WebAPI.Extensions;

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

// Configures the application's controller services and ensures that the controllers from the specified
// assembly (via the AssemblyReference class in WorkforceHubAPI.WebAPI.Presentation project) are included
// in the application's controller discovery process.
builder
    .Services.AddControllers()
    .AddApplicationPart(typeof(WorkforceHubAPI.WebAPI.Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
