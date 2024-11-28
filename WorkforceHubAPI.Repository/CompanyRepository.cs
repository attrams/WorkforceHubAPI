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

    /// <summary>
    /// Retrieves a specific company by its unique identifier from the database.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>The company entity with the specified identifier, or null if no match is found.</returns>
    public Company? GetCompany(Guid companyId, bool trackChanges)
    {
        return FindByCondition(company => company.Id.Equals(companyId), trackChanges).SingleOrDefault();
    }

    /// <summary>
    /// Retrieves a collection of companies whose IDs match the specified list of GUIDs.
    /// </summary>
    /// <param name="companyIds">A collection of GUIDs representing the IDs of the companies to retrieve.</param>
    /// <param name="trackChanges">
    /// A boolean indicating whether the entities should be tracked by the context.
    /// Set to true to enable tracking; otherwise, false for no tracking.
    /// </param>
    /// <returns>A collection of companies matching the provided IDs.</returns>
    public IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges)
    {
        return FindByCondition(company => companyIds.Contains(company.Id), trackChanges).ToList();
    }

    /// <summary>
    /// Implements the creation of a new company entity by using the base repository 'Create' method.
    /// </summary>
    /// <param name="company">The company entity to be created.</param>
    public void CreateCompany(Company company)
    {
        Create(company);
    }
}
