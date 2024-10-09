using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Employee")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Employee> Get()
    {
        return _employeeRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Employee> GetById(int id)
    {
       return await _employeeRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Post(Employee employee)
    {
        await _employeeRepository.AddAsync(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null) return NotFound();

        _employeeRepository.RemoveAsync(employee);
        return NoContent();
    }
}

}

