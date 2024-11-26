using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller for managing company-related API endpoints.
/// </summary>
[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompaniesController"/> class.
    /// </summary>
    /// <param name="service">
    /// An instance of <see cref="IServiceManager"/> that provides access to the business logic related to companies.
    /// </param>
    public CompaniesController(IServiceManager service)
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
    public IActionResult GetCompanies()
    {
        var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

        // Returns a 200 OK response with the list of companies.
        return Ok(companies);

    }
}
