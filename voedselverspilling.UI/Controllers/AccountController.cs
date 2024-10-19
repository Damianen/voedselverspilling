using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.Controllers {

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}

}
