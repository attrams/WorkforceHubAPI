using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WorkforceHubAPI.Repository;

namespace WorkforceHubAPI.WebAPI.ContextFactory;

/// <summary>
/// Factory for creating instances of <see cref="RepositoryContext"/> at design time.
/// </summary>
/// <remarks>
/// This class is used by design-time tools like Entity Framework migrations to create an instance
/// of the DbContext with the necessary configuration.
/// </remarks>
public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{

    /// <summary>
    /// Creates a new instance of <see cref="RepositoryContext"/> configured with the connection string.
    /// </summary>
    /// <param name="args">Arguments passed by the design-time tool.</param>
    /// <returns>A configured <see cref="RepositoryContext"/> instance.</returns>
    public RepositoryContext CreateDbContext(string[] args)
    {
        // Build the configuration object:
        // - Sets the base path to the current directory for locating configuration files.
        // - Loads the main appsettings.json file.
        // - Loads user secrets for sensitive configuration like connection strings.
        // - Adds environment variables for additional flexibility in configuration.
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<RepositoryContextFactory>()
            .AddEnvironmentVariables()
            .Build();

        // Retrieve the connection string named "DefaultConnection" from the configuration.
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configure the DbContext options to use SQL Server with the specified connection string.
        // Specifies the assembly ("WorkforceHubAPI.WebAPI") where migrations will be stored since the migration
        // assembly is not in this project but the WorkforceHubAPI.Repository project, ensuring the migrations
        // are kept in this project.
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(connectionString, b => b.MigrationsAssembly("WorkforceHubAPI.WebAPI"));

        return new RepositoryContext(builder.Options);
    }
}