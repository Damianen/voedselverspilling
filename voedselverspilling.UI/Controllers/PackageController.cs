using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using voedselverspilling.UI.Models;

namespace voedselverspilling.UI.Controllers;

public class PackageController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PackageController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Package()
    {
        return View();
    }
}
