using BusinessLogicLayer.DTOs.TADTOs;
using BusinessLogicLayer.TAService;
using College_portal_System.Utilities;
using College_portal_System.ViewModels.TAViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;

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

        private TADataViewModel GetTAData(string id)
        {
            var taData = _taService.GetTAGeneralInfo(id);
            return new TADataViewModel()
            {
                TAID = taData.NationalID,
                FullName = $"{taData.FName} {taData.LName}" ,
                Picture = taData.Image
            };
        }

        private List<TACoursesViewModel> GetTACourses(string id)
        {
            var taCourses = _taService.GetTACourses(id).Select(dto =>
            new TACoursesViewModel
            {
                CourseID = dto.CourseID,
                CourseName = dto.CourseName,
                ProfessorName = dto.ProfessorName
            }).ToList();
            return taCourses;
        }

        private UpdateProfileViewModel GetAllTAData(string id)
        {
            var taData = _taService.GetTAGeneralInfo(id);
            return new UpdateProfileViewModel()
            {
                NationalID = taData.NationalID,
                Email = taData.Email,
                Address = taData.Address,
                FName = taData.FName,
                LName = taData.LName,
                Password = taData.Password,
                ImageBase64 = taData.Image != null ? ImageHandler.GetBase64Image(taData.Image) : null
            };
        }

        // GET: TeachingAssistantController
        //[Authorize]
        public ActionResult Index()
        {
            ViewBag.ID = "30403468745632";
            var taCourses = GetTACourses(ViewBag.ID);
            ViewData["TACourses"] = taCourses;
            return View();
        }
        public IActionResult MyCourses()
        {
            ViewBag.ID = "30403468745632";
            var taCourses = GetTACourses(ViewBag.ID);
            ViewData["TACourses"] = taCourses;
            return View("TACourses" , taCourses);
        }
        [HttpGet]
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
            var TAId = "30403468745632";
            var viewModel = new CreateTaskViewModel()
            {
                Courses = GetTACourses(TAId).Select(c => new SelectListItem()
                {
                    // Because the course Id in task entity in nullable
                    Value = c.CourseID.HasValue ? c.CourseID.Value.ToString() : "0",
                    Text = c.CourseName
                })
                .ToList(),
                Tasks = _taService.GetTATasks(TAId)
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UpdateProfile()
        {
            ViewBag.ID = "30403468745632";
            var TA = GetAllTAData(ViewBag.ID);
            if(TA == null)
            {
                return NotFound("This TA is not found");
            }
            return View(TA);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(UpdateProfileViewModel updatedData)
        {
            var formData = Request.Form;
            if (!ModelState.IsValid)
            {
                return View(updatedData);
            }
            var dataToUpdate = new TADataDTO()
            {
                NationalID = updatedData.NationalID,
                Email = updatedData.Email,
                Address = updatedData.Address,
                FName = updatedData.FName,
                LName = updatedData.LName,
                Password = updatedData.Password,
                Image = ImageHandler.ChangeIFormImageToBinary(updatedData.Image)
            };
            _taService.UpdateTAProfile(dataToUpdate);
            return View("index");
        }
        public ActionResult Results()
        {
            return View();
        }
    }
}
