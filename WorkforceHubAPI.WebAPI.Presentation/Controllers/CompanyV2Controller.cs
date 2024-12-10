using System.Text.Json;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
[ApiExplorerSettings(GroupName = "v2")]
public class CompanyV2Controller : ControllerBase
{
    private readonly IServiceManager _service;

    public CompanyV2Controller(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
    {
        var (companies, metaData) = await _service.CompanyService.GetAllCompaniesAsync(companyParameters, trackChanges: false);
        var companiesV2 = companies.Select(company => $"{company.Name} V2");

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(companiesV2);
    }
}