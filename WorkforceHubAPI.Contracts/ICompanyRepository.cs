using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Defines a contract for a repository that manages <see cref="Company"/> entities.
/// This interface will be implemented to add methods specific to <see cref="Company"/> entity operations.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Retrieves a paginated list of companies, with support for pagination and filtering based on query parameters.
    /// </summary>
    /// <param name="companyParameters">
    /// An instance of <see cref="CompanyParameters"/> that contains pagination and filtering details for the query.
    /// This parameter specifies the page number, page size, and any additional filters to apply when retrieving the companies.
    /// </param>
    /// <param name="trackChanges">
    /// A flag indicating whether changes to the data should be tracked in the context.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a <see cref="PagedList{T}"/> 
    /// containing the list of <see cref="Company"/> entities for the current page, along with pagination metadata.
    /// </returns>
    /// <remarks>
    /// This method is used to retrieve companies in a paginated format. It supports filtering and pagination 
    /// based on the values provided in the <paramref name="companyParameters"/>. 
    /// The result includes a paginated list of companies and metadata about the pagination, 
    /// such as total count, current page, and total pages.
    /// </remarks>
    Task<PagedList<Company>> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges);

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
