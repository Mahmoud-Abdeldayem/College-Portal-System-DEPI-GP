using Microsoft.AspNetCore.Mvc;

namespace College_portal_System.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MaterialDetails() {
            return View();
        }
        public IActionResult Materials()
        {
            return View();
        }
    }
}
