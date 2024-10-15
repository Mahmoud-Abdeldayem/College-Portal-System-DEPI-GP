using BusinessLogicLayer.TAService;
using College_portal_System.Models.TAViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace College_portal_System.Controllers
{
    //[Authorize(Roles = "TA")]
    public class TeachingAssistantController : Controller
    {
        private readonly TAService _taService;

        public TeachingAssistantController(TAService service)
        {
            _taService = service;
        }

        // GET: TeachingAssistantController
        //[Authorize]
        public ActionResult Index()
        {
            ViewBag.ID = "30403468745632";
            var taCourses = _taService.GetTACourses((string)ViewBag.ID).Select(dto =>
            new TACoursesViewModel
            {
                CourseID = dto.CourseID,
                CourseName = dto.CourseName,
                ProfessorName = dto.ProfessorName
            }).ToList();
            ViewData["TACourses"] = taCourses;
            return View();
        }

        public IActionResult MyCourses(string id)
        {
            ViewBag.ID = "30403468745632";
            var taCourses = _taService.GetTACourses(id).Select(dto =>
            new TACoursesViewModel{
                CourseID = dto.CourseID ,
                CourseName = dto.CourseName , 
                ProfessorName = dto.ProfessorName
            }).ToList();
            ViewData["TACourses"] = taCourses;
            return View("TACourses" , taCourses);
        }
        public ActionResult Assignments()
        {
            return View();
        }

        public ActionResult EditAssignments()
        {
            return View();
        }
        public ActionResult CreateTask()
        {
            return View();
        }

        public ActionResult Results()
        {
            return View();
        }
    }
}
