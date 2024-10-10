using Microsoft.AspNetCore.Mvc;

namespace College_portal_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
