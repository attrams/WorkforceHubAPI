using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.OutputCaching;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.Shared.RequestFeatures;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;
using WorkforceHubAPI.WebAPI.Presentation.ModelBinders;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller for managing company-related API endpoints.
/// </summary>
[Route("api/companies")]
[ApiController]
[OutputCache(PolicyName = "120SecondsDuration")]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;

    private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollectionProvider;

    public CompanyController(IServiceManager service, IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider)
    {
        _service = service;
        _apiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
    }

    /// <summary>
    /// Handles the HTTP OPTIONS request for the controller by dynamically determining supported HTTP methods.
    /// </summary>
    /// <returns>
    /// A response containing the "Allow" header with the supported HTTP mrthods.
    /// </returns>
    [HttpOptions]
    public IActionResult GetCompanyControllerOptions()
    {
        // Retrieves the name of the current controller (e.g, "ExampleController" -> "Example").
        var controllerName = ControllerContext.ActionDescriptor.ControllerName;

        // Get all API descriptions for the actions in the application, filtering by the current controller. 
        var apiDescriptions = _apiDescriptionGroupCollectionProvider.ApiDescriptionGroups.Items
            .SelectMany(apiDescriptionGroup => apiDescriptionGroup.Items)
            .Where(apiDescription => apiDescription.ActionDescriptor.RouteValues["controller"] == controllerName);

        // Extract and remove duplicate supported HTTP methods for the current controller.
        var supportedMethods = apiDescriptions
            .Select(description => description.HttpMethod)
            .Distinct()
            .ToArray();

        Response.Headers.Append("Allow", string.Join(", ", supportedMethods));

        return Ok();
    }

    /// <summary>
    /// Retrieves a paginated list of companies based on the provided query parameters.
    /// </summary>
    /// <param name="companyParameters">
    /// An instance of <see cref="CompanyParameters"/> containing pagination and filtering details, 
    /// such as page number, page size, and any additional filtering criteria.
    /// </param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing:
    ///     <para>- An HTTP 200 OK response with the paginated list of companies and pagination metadata.</para>
    ///     <para>- An appropriate error response if the request fails.</para>
    /// </returns>
    /// <remarks>
    /// This method retrieves a paginated list of companies from the service layer based on the query parameters provided 
    /// in <paramref name="companyParameters"/>. Pagination metadata such as total count, current page, and total pages 
    /// are included in the response.
    /// </remarks>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
    {
        var (companies, metaData) = await _service.CompanyService.GetAllCompaniesAsync(companyParameters, trackChanges: false);
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));

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
