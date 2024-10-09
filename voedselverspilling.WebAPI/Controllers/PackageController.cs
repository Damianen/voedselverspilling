using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Package")]
public class PackageController : ControllerBase
{
    private readonly ILogger<PackageController> _logger;
    private readonly IPackageRepository _packageRepository;

    public PackageController(ILogger<PackageController> logger, IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Package> Get()
    {
        return _packageRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Package> GetById(int id)
    {
       return await _packageRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Package>> Post(Package package)
    {
        await _packageRepository.AddAsync(package);
        return CreatedAtAction(nameof(Get), new { id = package.Id }, package);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Package package)
    {
        await _packageRepository.UpdateAsync(package);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var package = await _packageRepository.GetByIdAsync(id);
        if (package == null) return NotFound();

        _packageRepository.RemoveAsync(package);
        return NoContent();
    }
}

}
