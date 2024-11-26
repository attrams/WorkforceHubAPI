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
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
}
