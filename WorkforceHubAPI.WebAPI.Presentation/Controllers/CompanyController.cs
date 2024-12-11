using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.OutputCaching;
using WorkforceHubAPI.Entities.ErrorModel;
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
[ApiExplorerSettings(GroupName = "v1")]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;

    private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollectionProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyController"/> class.
    /// </summary>
    /// <param name="service">
    /// An instance of <see cref="IServiceManager"/> used to manage services related to company operations.
    /// </param>
    /// <param name="apiDescriptionGroupCollectionProvider">
    /// An instance of <see cref="IApiDescriptionGroupCollectionProvider"/> used to dynamically retrieve actions for the OPTIONS method in the current
    /// controller to avoid the need to hardcode them.
    /// </param>
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
    /// <response code="200">Returns the supported HTTP methods for the current controller in the response header.</response>
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
    /// <response code="200">Returns the list of companies with pagination metadata.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="404">If no companies are found.</response>
    [HttpGet]
    [Authorize(Roles = "Manager")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Text.Csv, MediaTypeNames.Text.Xml)]
    [ProducesResponseType(typeof(List<CompanyDto>), statusCode: StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
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
    /// <response code="200">Returns the company details.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="404">If the company is not found.</response>
    [HttpGet("{id}", Name = "CompanyById")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Text.Csv, MediaTypeNames.Text.Xml)]
    [ProducesResponseType(typeof(CompanyDto), statusCode: StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
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
    /// <response code="200">Returns the collection of companies.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="404">If any company is not found.</response>
    [HttpGet("collection", Name = "CompanyCollection")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Text.Csv, MediaTypeNames.Text.Xml)]
    [ProducesResponseType(typeof(List<CompanyDto>), statusCode: StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
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
    /// <response code="201">Returns the newly created item.</response>
    /// <response code="400">If the item is null.</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CompanyDto), statusCode: StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status422UnprocessableEntity, MediaTypeNames.Application.Json)]
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
    /// <response code="201">Returns the a list of the newly created items.</response>
    /// <response code="400">If an item is null.</response>
    /// <response code="422">If an item is invalid</response>
    [HttpPost("collection")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<CompanyDto>), statusCode: StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status422UnprocessableEntity, MediaTypeNames.Application.Json)]
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
    /// <response code="204">Indicates that the company was successfully deleted.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="404">If the company is not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
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
    /// <response code="204">Empty Response</response>
    /// <response code="400">If the item is null.</response>
    /// <response code="422">If the model is invalid.</response>
    [HttpPut("{companyId}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status422UnprocessableEntity, MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateCompany(string companyId, [FromBody] CompanyForUpdateDto company)
    {
        await _service.CompanyService.UpdateCompanyAsync(companyId, company, trackChanges: true);

        return NoContent();
    }
}
