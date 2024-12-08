using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Repository.Configuration;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the database context for the application.
/// </summary>
/// <remarks>
/// The <see cref="RepositoryContext"/> class is responsible for interacting with the database.
/// It defines the DbSet properties for the applications's domain models and is configured using Entity Framework Core.
/// </remarks>
public class RepositoryContext : IdentityDbContext<User>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    /// <remarks>
    /// The options parameter allows external configuration of the database context, such as connection string and provider settings.
    /// </remarks>
    public RepositoryContext(DbContextOptions options)
        : base(options) { }

    /// Override the OnModelCreating method to apply configurations and seed data for the entities.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations and seed data for Company, Employee and Role entities.
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="Company"/> entity.
    /// </summary>
    /// <remarks>
    /// This property provides access to the Companies table in the database.
    /// </remarks>
    public DbSet<Company>? Companies { get; set; }

    /// <summary>
    /// Get or sets the <see cref="DbSet{TEntity}"/> for the <see cref="Employee"/> entity.
    /// </summary>
    /// <remarks>
    /// This property provides access to the Employees table in the database.
    /// </remarks>
    public DbSet<Employee>? Employees { get; set; }
}
