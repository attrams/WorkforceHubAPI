using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Represents an alternative version of the Company controller.
/// </summary>
[Route("api/companies")]
[ApiController]
[ApiExplorerSettings(GroupName = "v2")]
public class CompanyV2Controller : ControllerBase
{
    private readonly IServiceManager _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyV2Controller"/> class.
    /// </summary>
    /// <param name="service">An instance of <see cref="IServiceManager"/> used to access business logic and data services for companies.</param>
    public CompanyV2Controller(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves a list of companies with version-specific formatting and includes pagination metadata in the response headers.
    /// </summary>
    /// <param name="companyParameters">
    /// The query parameters for pagination and filtering of companies.
    /// </param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the list of companies with "V2" appended to their names, 
    /// along with pagination metadata in the response headers.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
    {
        var (companies, metaData) = await _service.CompanyService.GetAllCompaniesAsync(companyParameters, trackChanges: false);
        var companiesV2 = companies.Select(company => $"{company.Name} V2");

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(companiesV2);
    }
}