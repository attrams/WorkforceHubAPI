using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the repository implementation for managing <see cref="Company"/> entities.
/// Inherits common repository logic from <see cref="RepositoryBase{Company}"/> and implements
/// the <see cref="ICompanyRepository"/> interface for defining additional model-specific methods.
/// </summary>
public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }
}
