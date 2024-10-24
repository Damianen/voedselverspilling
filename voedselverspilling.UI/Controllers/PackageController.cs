using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;
using System.Collections.Immutable;

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
        var packages = _packageRepo.GetAll().Where(package => package.Resorvation == null) ?? [];
        return View(packages.ToList());
    }

    public IActionResult Breakfast()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Breakfast).Where(package => package.Resorvation == null) ?? [];
        return View("index", packages.ToList());
    }

    public IActionResult Lunch()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Lunch).Where(package => package.Resorvation == null) ?? [];
        return View("index", packages.ToList());
    }

    public IActionResult Dinner()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Dinner).Where(package => package.Resorvation == null) ?? [];
        return View("index", packages.ToList());
    }

    public IActionResult Snack()
    {
        var packages = _packageRepo.GetAllWithMealType(MealTypes.Snack).Where(package => package.Resorvation == null) ?? [];
        return View("index", packages.ToList());
    }

    [Route("Packages/{id}")]
    public IActionResult Package(int id)
    {
        var package = _packageRepo.GetById(id) ?? new Package();
        return View(package);
    }
}
