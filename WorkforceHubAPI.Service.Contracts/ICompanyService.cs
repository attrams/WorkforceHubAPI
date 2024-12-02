using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.Service.Contracts;

/// <summary>
/// Interface for defining business logic operations related to the Company entity.
/// This serves as a contract for implementing Company-related service logic.
/// </summary>
public interface ICompanyService
{
    /// <summary>
    /// Provides functionality to retrieve all companies from the database.
    /// </summary>
    /// <param name="trackChanges">
    /// A boolean flag indicating whether to track changes to the entities. If true, changes to
    /// the entities are tracked by the context. If false, entities are queried without tracking.
    /// </param>
    /// <returns>
    /// A collection of all companies in the database.
    /// </returns>
    Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);

    /// <summary>
    /// Retrieves a collection of companies based on the provided IDs.
    /// </summary>
    /// <param name="companyIds">A collection strings representing the IDs of the companies to retrieve.</param>
    /// <param name="trackChanges">
    /// A boolean value indicating whether changes to the entities should be tracked by the context.
    /// If set to true, the context tracks changes, otherwise it does not.
    /// </param>
    /// <returns>A collection of <see cref="CompanyDto"/> representing the retrieved companies.</returns>
    Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<string> companyIds, bool trackChanges);

    /// <summary>
    /// Retrieves a specific company by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>A data transfer object (DTO) representing the company with the specified identifier.</returns>
    Task<CompanyDto> GetCompanyAsync(string companyId, bool trackChanges);

    /// <summary>
    /// Creates a new company based on the provided data in the data transfer object.
    /// </summary>
    /// <param name="company">The data transfer object containing the details of the company to be created.</param>
    /// <returns>The created company as a data transfer object.</returns>
    Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

    /// <summary>
    /// Creates multiple companies and returns the created companies along with their IDs as a string.
    /// </summary>
    /// <param name="companyCollection">The collection of companies to be created.</param>
    /// <returns>
    /// A tuple containing:
    /// - companies: The collection of created companies as DTos.
    /// - companyIds: A comma-seperated string of the IDs of the created companies.
    /// </returns>
    Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

    /// <summary>
    /// Deletes a company based on the provided company ID.
    /// </summary>
    /// <param name="companyId">The ID of the company to delete.</param>
    /// <param name="trackChanges">Indicates whether to track changes to the entity in the database context.</param>
    Task DeleteCompanyAsync(string companyId, bool trackChanges);

    /// <summary>
    /// Updates the details of an existing company based on the provided ID and the data transfer object.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to update.</param>
    /// <param name="companyForUpdate">An object containing the updated details of the company.</param>
    /// <param name="trackChanges">
    /// A boolean value indicating whether to track changes to the company entity during the update.
    /// Set to true for updates involving tracked entities, false otherwise.    
    /// </param>
    Task UpdateCompanyAsync(string companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
}
