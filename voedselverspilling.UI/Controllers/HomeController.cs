using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.Controllers {

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

}
