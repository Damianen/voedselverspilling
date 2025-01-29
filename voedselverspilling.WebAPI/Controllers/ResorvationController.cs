using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Resorvation")]
public class ResorvationController : ControllerBase
{
    private readonly ILogger<CanteenController> _logger;
    private readonly IResorvationRepository _resorvationRepository;

    public ResorvationController(ILogger<CanteenController> logger, IResorvationRepository resorvationRepository)
    {
        _resorvationRepository = resorvationRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Resorvation> Get()
    {
        return _resorvationRepository.GetAll();
    }

    [HttpPost]
    public async Task<ActionResult<Resorvation>> Post(Resorvation resorvation)
    {
        await _resorvationRepository.AddAsync(resorvation);
        return CreatedAtAction(nameof(Get), new { id = resorvation.Id }, resorvation);
    }
}

}
