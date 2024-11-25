using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using WorkforceHubAPI.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddSimpleConsole().AddDebug();

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

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
