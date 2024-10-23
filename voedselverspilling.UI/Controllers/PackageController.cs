using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.UI.Models;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.UI.Controllers;

public class PackageController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepo;

    public PackageController(ILogger<HomeController> logger, IPackageRepository packageRepo)
    {
        _logger = logger;
        _packageRepo = packageRepo;
    }

    public IActionResult Index()
    {
        var packages = _packageRepo.GetAll() ?? new List<Package>();
        return View(packages.ToList());
    }

    public IActionResult Breakfast()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Breakfast) ?? new List<Package>();
        return View("index", packages.ToList());
    }

    public IActionResult Lunch()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Lunch) ?? new List<Package>();
        return View("index", packages.ToList());
    }

    public IActionResult Dinner()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Dinner) ?? new List<Package>();
        return View("index", packages.ToList());
    }

    public IActionResult Snack()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Snack) ?? new List<Package>();
        return View("index", packages.ToList());
    }

    public IActionResult Package()
    {
        return View();
    }
}
