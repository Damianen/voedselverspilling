using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Student")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentRepository _studentRepository;

    public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return _studentRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Student> GetById(int id)
    {
       return await _studentRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Post(Student student)
    {
        await _studentRepository.AddAsync(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Student student)
    {
        await _studentRepository.UpdateAsync(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null) return NotFound();

        _studentRepository.RemoveAsync(student);
        return NoContent();
    }
}

}
