using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller to handle requests related to employees of a specific company.
/// </summary>
[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeeController(IServiceManager service) => _service = service;

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
    [HttpGet("{employeeId}", Name = "GetEmployeeForCompany")]
    public IActionResult GetEmployeeForCompany(string companyId, string employeeId)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);

        return Ok(employee);
    }

    /// <summary>
    /// Handles the POST request to create a new employee for the specified company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company where the employee is being added.</param>
    /// <param name="employee">The data transfer object containing the employee details.</param>
    /// <returns>A response with the created employee data, including a URI to access the newly created employee's details.</returns>
    [HttpPost]
    public IActionResult CreateEmployeeForCompany(string companyId, [FromBody] EmployeeForCreationDto employee)
    {
        var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

        // Return the newly created employee with a route to access it, along with a 201 status code.
        return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employeeToReturn.Id }, employeeToReturn);
    }
}