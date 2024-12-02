using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Defines a contract for a repository that manages <see cref="Company"/> entities.
/// This interface will be implemented to add methods specific to <see cref="Company"/> entity operations.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Provides a method to retrieve all companies from the database.
    /// </summary>
    /// <param name="trackChanges">
    /// A boolean flag indicating whether to track changes to the entities. If true, changes to the entities
    /// are tracked by the context. If false, entities are queried without tracking.
    /// </param>
    /// <returns>
    /// A collection of all companies in the database.
    /// </returns>
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);

    /// <summary>
    /// Retrieves a specific company by its unique identifier.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>The company entity with the specified identifier, or null if no match is found.</returns>
    Task<Company?> GetCompanyAsync(Guid companyId, bool trackChanges);

    /// <summary>
    /// Retrieves a collection of companies based on the specified list of company IDs.
    /// </summary>
    /// <param name="companyIds">A collection of GUIDs representing the IDs of the companies to retrieve.</param>
    /// <param name="trackChanges">
    /// A boolean indicating whether the entities should be tracked by the context.
    /// Set to true to enable tracking; otherwise, false for no tracking.
    /// </param>
    /// <returns>A collection of companies matching the provided IDs.</returns>
    Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges);

    /// <summary>
    /// Adds a new company entity.
    /// </summary>
    /// <param name="company">The company entity to be created.</param>
    void CreateCompany(Company company);

    /// <summary>
    /// Deletes the specified company entity from the database.
    /// </summary>
    /// <param name="company">The company entity to be deleted.</param>
    void DeleteCompany(Company company);
}
