using BusinessLogicLayer.AuthenticationService.Implementations;
using College_portal_System.Extensions;
using College_portal_System.ViewModels.UserViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace College_portal_System.Controllers
{
    public class AuthController(IUserService userService) : Controller
    {        
        private readonly IUserService _userService = userService;        
        public IActionResult Index()
        {
            return View("AddStudent");
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateProfessor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTA()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(ApplicationUserFormVM model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/CreateStudent.cshtml", model);

            var user = model.MapToModel();

            var newAppUser = await _userService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View("~/Views/Admin/CreateStudent.cshtml", model);
            }

            var student = _userService.CreateStudent(model: user, userModel: newAppUser.AppUser);

            if (!student.IsSucceded)
            {
                ModelState.AddModelError(string.Empty, student.ErrorMessage!);
                return View("~/Views/Admin/CreateStudent.cshtml", model);
            }

            return RedirectToAction("StudentIndex", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessorAsync(ProfessorFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = model.MapToModel();

            var newAppUser = await _userService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeachingAssistantAsync(TAFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = model.MapToModel();

            var newAppUser = await _userService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View();
            }            

            return View();
        }        
    }
}
