using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the repository implementation for managing <see cref="Employee"/> entities.
/// Inherits common repository logic from <see cref="RepositoryBase{Employee}"/> and implements
/// the <see cref="IEmployeeRepository"/> interface for defining additional model-specific methods.
/// </summary>
public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }
}
