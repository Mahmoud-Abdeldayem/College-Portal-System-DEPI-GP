using Microsoft.AspNetCore.Mvc;

namespace College_portal_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Mahmoud Abdeldayem";
            return View();
        }

        public IActionResult AddStudent()
        {
            return View();
        }


        //----------------------------------------<Courses>---------------------------------------

        public IActionResult Courses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(int id)
        {
            return View();
        }
        //----------------------------------------<Courses>---------------------------------------
        public IActionResult EditStudent()
        {
            return View();
        } 
    }
}
