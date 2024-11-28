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
    IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);

    /// <summary>
    /// Retrieves a specific company by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>A data transfer object (DTO) representing the company with the specified identifier.</returns>
    CompanyDto GetCompany(string companyId, bool trackChanges);

    /// <summary>
    /// Creates a new company based on the provided data in the data transfer object.
    /// </summary>
    /// <param name="company">The data transfer object containing the details of the company to be created.</param>
    /// <returns>The created company as a data transfer object.</returns>
    CompanyDto CreateCompany(CompanyForCreationDto company);
}
