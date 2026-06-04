using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IEmployeeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Employee>>> GetAllEmployees()
    {
        var employees = await service.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var emp = await service.GetEmployeeByIdAsync(id);
        if (emp is null)
        {
            return NotFound();
        }

        return Ok(emp);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmpResDto dto)
    {
        var emp = new Employee
        {
            Name = dto.Name,
            Department = dto.Department
        };

        var createdEmp = await service.AddEmployeeAsync(emp);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmp.Id },
            createdEmp);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var emp = await service.DeleteEmployeeAsync(id);

        if (!emp)
        {
            return NotFound();
        }

        return NoContent();
    }
}