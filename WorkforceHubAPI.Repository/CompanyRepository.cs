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

    /// <summary>
    /// Retrieves all companies from the database and orders them by their name.
    /// </summary>
    /// <param name="trackChanges">
    /// A boolean flag indicating whether to track changes to the entities. If true, changes to the entities are
    /// tracked by the context. If false, entities are queried without tracking.
    /// </param>
    /// <returns>
    /// A collection of all companies, ordered by their name.
    /// </returns>
    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(company => company.Name).ToList();
    }
}
