using Microsoft.AspNetCore.Mvc;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;
using Microsoft.AspNetCore.Identity;
using voedselverspilling.Infrastructure;

namespace voedselverspilling.UI.Controllers;

public class ResorvationController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IResorvationRepository _resorvationRepo;
    private readonly IPackageRepository _packageRepo;
    private readonly SignInManager<IdentityUser> _signInManager;

    public ResorvationController(ILogger<HomeController> logger, IResorvationRepository resorvationRepo, 
        IPackageRepository packageRepo, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _resorvationRepo = resorvationRepo;
        _packageRepo = packageRepo;
        _signInManager = signInManager;
    }

    [Route("/Resorvation/{id}")]
    [HttpPost]
    public async Task<IActionResult> Index(int id, string returnUrl)
    {
        if (!_signInManager.IsSignedIn(User)) { return RedirectToPage("/"); }

        var res = new Resorvation
        {
            StudentId = _signInManager.UserManager.GetUserId(User) ?? "",
            Package = _packageRepo.GetById(id),
            Status = ResorvationStatus.Reserved
        };
        
        await _resorvationRepo.AddAsync(res);

        return LocalRedirect(returnUrl);
    }
}