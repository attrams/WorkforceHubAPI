using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller to handle requests related to employees of a specific company.
/// </summary>
[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service) => _service = service;

    /// <summary>
    /// Retrieves all employees for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>An <see cref="IActionResult"/> containing a list of employees for the specific company.</returns>
    [HttpGet]
    public IActionResult GetEmployeesForCompany(string companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);

        return Ok(employees);
    }

    /// <summary>
    /// Retrieves a specific employee for a specific company
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifier of the employee.</param>
    /// <returns>An <see cref="IActionResult"/> containing the details of the specified employee.</returns>
    [HttpGet("{employeeId}")]
    public IActionResult GetEmployeeForCompany(string companyId, string employeeId)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);

        return Ok(employee);
    }
}