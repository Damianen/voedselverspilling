using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Canteen")]
public class CanteenController : ControllerBase
{
    private readonly ILogger<CanteenController> _logger;
    private readonly ICanteenRepository _canteenRepository;

    public CanteenController(ILogger<CanteenController> logger, ICanteenRepository canteenRepository)
    {
        _canteenRepository = canteenRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Canteen> Get()
    {
        return _canteenRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Canteen> GetById(int id)
    {
       return await _canteenRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Canteen>> Post(Canteen canteen)
    {
        await _canteenRepository.AddAsync(canteen);
        return CreatedAtAction(nameof(Get), new { id = canteen.Id }, canteen);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Canteen canteen)
    {
        await _canteenRepository.UpdateAsync(canteen);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var canteen = await _canteenRepository.GetByIdAsync(id);
        if (canteen == null) return NotFound();

        _canteenRepository.RemoveAsync(canteen);
        return NoContent();
    }
}

}
