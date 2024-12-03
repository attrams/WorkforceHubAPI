using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;
using WorkforceHubAPI.WebAPI.Presentation.ModelBinders;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller for managing company-related API endpoints.
/// </summary>
[Route("api/companies")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyController"/> class.
    /// </summary>
    /// <param name="service">
    /// An instance of <see cref="IServiceManager"/> that provides access to the business logic related to companies.
    /// </param>
    public CompanyController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all companies from the database.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the list of companies in the database or an error response if something 
    /// goes wrong.
    /// </returns>
    /// <remarks>
    /// This endpoint fetches all companies without tracking changes in the database context.
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);

        // Returns a 200 OK response with the list of companies.
        return Ok(companies);
    }

    /// <summary>
    /// Retrieves a specific company by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the company to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the company data transfer object (DTO) if found.</returns>
    [HttpGet("{id}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompany(string id)
    {
        var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);

        return Ok(company);
    }

    /// <summary>
    /// Retrieves a collection of companies based on the provided IDs.
    /// </summary>
    /// <param name="companyIds">A collection of strings representing IDs of the companies to retrieve.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing an HTTP 200 OK response with the collection of companies if the 
    /// retrieval is successful.
    /// </returns>
    [HttpGet("collection", Name = "CompanyCollection")]
    public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<string> companyIds)
    {
        var companies = await _service.CompanyService.GetByIdsAsync(companyIds, trackChanges: false);

        return Ok(companies);
    }

    /// <summary>
    /// Handles the POST request to create a new company.
    /// </summary>
    /// <param name="company">The data transfer object containing the company details.</param>
    /// <returns>
    /// A 201 Created response with the location of the newly created company and its details.
    /// </returns>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
    {
        var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);

        // Return the created company with the appropriate route for retrieving it.
        return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
    }

    /// <summary>
    /// Creates multiple companies in a single POST request.
    /// </summary>
    /// <param name="companyCollection">
    /// The collection of companies to be created, provided as a list of <see cref="CompanyForCreationDto"/> objects.
    /// </param>
    /// <returns>
    /// An HTTP response indicating the result of the creation operation:
    /// - On success, returns a `201 Created` response containing the newly created companies and their IDs.
    /// - If the provided company collection is null or empty, returns a `400 Bad Request` response.
    /// </returns>
    [HttpPost("collection")]
    public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var (companies, companyIds) = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
        var queryString = new { companyIds = string.Join(",", companyIds) };

        return CreatedAtRoute("CompanyCollection", queryString, companies);
    }

    /// <summary>
    /// Handles the HTTP DELETE request to delete a specific company by its ID.
    /// </summary>
    /// <param name="companyId">The ID of the company to delete.</param>
    /// <returns>A NoContent (204) response if the deletion is successful. </returns>
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> DeleteCompany(string companyId)
    {
        await _service.CompanyService.DeleteCompanyAsync(companyId, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Updates an existing company's details based on the provided company ID and update data.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to update.</param>
    /// <param name="company">
    /// An object containing the updated details of the company, including optional updates to associated employees.
    /// </param>
    /// <returns>Returns a <see cref="NoContentResult"/> if the update operation is successful.</returns>
    [HttpPut("{companyId}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCompany(string companyId, [FromBody] CompanyForUpdateDto company)
    {
        await _service.CompanyService.UpdateCompanyAsync(companyId, company, trackChanges: true);

        return NoContent();
    }
}
