using Microsoft.AspNetCore.Mvc;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.Controllers {

public class HomeController : Controller
{
    Student st = new Student();

    public IActionResult Index()
    {
        return View();
    }
}

}
