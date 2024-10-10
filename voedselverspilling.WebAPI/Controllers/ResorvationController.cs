using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Resorvation")]
public class ResorvationController : ControllerBase
{
    private readonly ILogger<ResorvationController> _logger;
    private readonly IResorvationRepository _resorvationRepository;

    public ResorvationController(ILogger<ResorvationController> logger, IResorvationRepository resorvationRepository)
    {
        _resorvationRepository = resorvationRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Resorvation> Get()
    {
        return _resorvationRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Resorvation> GetById(int id)
    {
       return await _resorvationRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Resorvation>> Post(Resorvation resorvation)
    {
        await _resorvationRepository.AddAsync(resorvation);
        return CreatedAtAction(nameof(Get), new { id = resorvation.Id }, resorvation);
    }

    [HttpPost("{studentId}/{packageId}")]
    public async Task<ActionResult<Resorvation>> PostWithIds(int studentId, int packageId)
    {
        Resorvation resorvation = await _resorvationRepository.AddByIdsAsync(studentId, packageId);
        return CreatedAtAction(nameof(Get), new { id = resorvation.Id }, resorvation);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var resorvation = await _resorvationRepository.GetByIdAsync(id);
        if (resorvation == null) return NotFound();

        _resorvationRepository.RemoveAsync(resorvation);
        return NoContent();
    }
}

}
