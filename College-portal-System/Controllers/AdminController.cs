using BusinessLogicLayer.AdminService.Services;
using College_portal_System.Models.AdminViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College_portal_System.Controllers
{
    public class AdminController : Controller
    {

        private readonly AdminService _adminService;
        public AdminController(AdminService adminService) 
        { 
            _adminService = adminService;
        }
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
            var viewModel = new AddCourseViewModel()
            {
                Departments = _adminService.GetDepartments().Select(d => new SelectListItem()
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.Name 
                }).ToList(),
                PrerequisiteCourses = _adminService.GetCourses().Select(c => new SelectListItem()
                {
                    Value = c.CourseId.ToString(),
                    Text = c.Name
                }).ToList(),
            };
            viewModel.Departments.Add(new SelectListItem() { Value = null, Text = "No Prerequisite" });
            return View(viewModel);
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
