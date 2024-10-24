using BusinessLogicLayer.AuthenticationService.Implementations;
using College_portal_System.Extensions;
using College_portal_System.ViewModels.UserViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace College_portal_System.Controllers
{
    public class AuthController(UnitOfWork unitOfWork, IAdminService adminService, IUserService userService) : Controller
    {        
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAdminService _adminService = adminService;
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
                return View(model);            

            var user = model.MapToModel();

            var newAppUser = await _adminService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View(ModelState);
            }

            var student = await _userService.CreateStudentAsync(model: user, userModel: newAppUser.AppUser);

            if (!student.IsSucceded)
            {
                ModelState.AddModelError(string.Empty, student.ErrorMessage!);
                return View(ModelState);
            }

            return RedirectToAction("StudentIndex", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessorAsync(ProfessorFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = model.MapToModel();

            var newAppUser = await _adminService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View();
            }

            var prof = new Professor
            {
                ProfessorId = model.NationalId,
                ProfessorNavigation = newAppUser.AppUser!,    
                DepartmentId = model.DepartmentId,
                EnterYear = DateTime.Now.Year,
                DocUni = model.DocUni,                
                Title = model.Title,
                PhDat = model.PHDField,                
            };

            _unitOfWork.Professors.Insert(prof);
            _unitOfWork.Commit();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessorAsync(TAFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = model.MapToModel();

            var newAppUser = await _adminService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View();
            }

            var TA = new TeachingAssistant
            {
                Taid = model.NationalId,
                Ta = newAppUser.AppUser,
                AssistingProfessorId  = model.AssistingProfessorId, // Depends on the front end
                AcademicDegree = model.AcademicDegree,
                DepartmentId = model.DepartmentId, // Depends on the front end
                University = model.University,
                Faculty = model.Faculty,
            };

            _unitOfWork.TAs.Insert(TA);
            _unitOfWork.Commit();

            return View();
        }        
    }
}
