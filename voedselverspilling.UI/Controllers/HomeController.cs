using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.UI.Models;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace voedselverspilling.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepo;
    private readonly IResorvationRepository _resorvationRepo;
    private readonly SignInManager<IdentityUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepo, 
        IResorvationRepository resorvationRepo, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _packageRepo = packageRepo;
        _resorvationRepo = resorvationRepo;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        var packages = _packageRepo.GetAll().Where(package => package.Resorvation == null).Take(4) ?? [];
        return View(packages.ToList());
    }

    public IActionResult Account()
    {
        if (!_signInManager.IsSignedIn(User)) { return RedirectToPage("/"); }

        var resorvations = _resorvationRepo.GetByStudentId(_signInManager.UserManager.GetUserId(User) ?? "") ?? [];
        List<Package> packages = [];
        foreach (var resorvartion in resorvations)
        {
            packages.Add(resorvartion.Package);
        }
        return View(packages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
