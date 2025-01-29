using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace voedselverspilling.UI.Controllers;

public class PackageController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepo;
    private readonly IProductRepository _productRepo;

    public PackageController(ILogger<HomeController> logger, IPackageRepository packageRepo, 
        IProductRepository productRepo)
    {
        _logger = logger;
        _packageRepo = packageRepo;
        _productRepo = productRepo;
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

    [HttpGet]
    public IActionResult New()
    {
        NewModel newModel = new();
        newModel.Products = _productRepo.GetAllAsync().ToList();
        return View(newModel);
    }

    [HttpPost]
    public IActionResult NewPackage()
    {

        var packages = _packageRepo.GetAll().Where(package => package.Resorvation == null) ?? [];
        return View("index", packages.ToList());
    }

    public class NewModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public List<Product> Products { get; set; }
        public class InputModel {
            [Required]
            public required string Name { get; set; }

            [Required]
            public DateTime PickUp { get; set; }

            [Required]
            public int Price { get; set; }

            [Required]
            public string PhotoName { get; set; }

            [Required]
            public MealTypes Type { get; set; }
        }
    }
}
