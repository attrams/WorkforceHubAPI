using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

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
    public IActionResult GetCompanies()
    {
        var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

        // Returns a 200 OK response with the list of companies.
        return Ok(companies);
    }

    /// <summary>
    /// Retrieves a specific company by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the company to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the company data transfer object (DTO) if found.</returns>
    [HttpGet("{id}", Name = "CompanyById")]
    public IActionResult GetCompany(string id)
    {
        var company = _service.CompanyService.GetCompany(id, trackChanges: false);

        return Ok(company);
    }

    /// <summary>
    /// Handles the POST request to create a new company.
    /// </summary>
    /// <param name="company">The data transfer object containing the company details.</param>
    /// <returns>
    /// A 201 Created response with the location of the newly created company and its details.
    /// </returns>
    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
    {
        var createdCompany = _service.CompanyService.CreateCompany(company);

        // Return the created company with the appropriate route for retrieving it.
        return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
    }
}
