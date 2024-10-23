using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.UI.Models;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepo;

    public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepo)
    {
        _logger = logger;
        _packageRepo = packageRepo;
    }

    public IActionResult Index()
    {
        var packages = _packageRepo.GetAll().Take(4) ?? new List<Package>();
        return View(packages.ToList());
    }

    public IActionResult Account()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
