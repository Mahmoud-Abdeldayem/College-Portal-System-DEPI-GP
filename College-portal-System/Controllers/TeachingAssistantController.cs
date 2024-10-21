using BusinessLogicLayer.DTOs.TADTOs;
using BusinessLogicLayer.TAService;
using College_portal_System.Models.TAViewModels;
using College_portal_System.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Drawing;
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

        private CreateTaskViewModel GetCreateTaskViewModel(string taID)
        {
            var viewModel = new CreateTaskViewModel()
            {
                Courses = GetTACourses(taID).Select(c => new SelectListItem()
                {
                    // Because the course Id in task entity in nullable
                    Value = c.CourseID.HasValue ? c.CourseID.Value.ToString() : "0",
                    Text = c.CourseName
                })
                .ToList(),
                Tasks = _taService.GetTATasks(taID)
            };
            return viewModel;
        }
        //-----------------------------------<End of private methods>-----------------------------------------------
        // GET: TeachingAssistantController
        //[Authorize]
        public IActionResult Index()
        {
            ViewBag.ID = "30403468745632";
            ViewBag.Name = "Mahmoud";
            //var taCourses = GetTACourses(ViewBag.ID);
            //ViewData["TACourses"] = taCourses;
            return View();
        }
        public IActionResult MyCourses()
        {
            ViewBag.ID = "30403468745632";
            ViewBag.Name = "Mahmoud";
            var taCourses = GetTACourses(ViewBag.ID);
            ViewData["TACourses"] = taCourses;
            return View("TACourses" , taCourses);
        }
        [HttpGet]
        public IActionResult Assignments()
        {
            ViewBag.Name = "Mahmoud";
            return View();
        }

        public IActionResult EditAssignments()
        {
            ViewBag.Name = "Mahmoud";
            return View();
        }
        //------------------------------<Create Task>-----------------------------------------
        //TeachingAssistant/CreateTask : Get
        [HttpGet]
        public IActionResult CreateTask()
        {
            var TAId = "30403468745632";
            ViewBag.Name = "Mahmoud";
            var viewModel = GetCreateTaskViewModel(TAId);
            return View(viewModel);
        }

        //TeachingAssistant/CreateTask : Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(CreateTaskDTO task)
        {
            var taID = "30403468745632";
            ViewBag.Name = "Mahmoud";
            if (ModelState.IsValid)
            {
                var newTask = new CreateTaskDTO()
                {
                    CourseId = task.CourseId,
                    Grade = task.Grade,
                    Deadline = task.Deadline,
                    Content = task.Content,
                    Type = task.Type,
                    AssignedByTaid = taID,
                    TaskLink = task.TaskLink
                };
                _taService.CreateTask(newTask);
                return RedirectToAction("Index");
            }
            var viewModel = GetCreateTaskViewModel(taID); 
            return View(viewModel);
        }
        //------------------------------------<Create Quiz>-------------------------------------
        public IActionResult CreateQuiz()
        {
            ViewBag.Name = "Mahmoud";
            return View();
        }

        //------------------------------------<Update Profile>-------------------------------------

        [HttpGet]
        public IActionResult UpdateProfile()
        {
            ViewBag.ID = "30403468745632";
            ViewBag.Name = "Mahmoud";
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
            ViewBag.Name = "Mahmoud";
            var formData = Request.Form;
            if (ModelState.IsValid)
            {
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
                return RedirectToAction("index");
            }
            return View(updatedData);
        }

        //------------------------------------<Results>-------------------------------------

        public IActionResult Results()
        {
            ViewBag.Name = "Mahmoud";
            return View();
        }
        //------------------------------------<Edit Task>-------------------------------------

        [HttpGet]
        public IActionResult EditTask()
        {
            return View();
        }
    }
}
