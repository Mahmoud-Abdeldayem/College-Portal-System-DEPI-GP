using BusinessLogicLayer.AdminService.Implementations;
using BusinessLogicLayer.AdminService.Services;
using BusinessLogicLayer.DTOs.Users;
using College_portal_System.Extensions;
using College_portal_System.Models.UserViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace College_portal_System.Controllers
{
    public class AdminController(UnitOfWork unitOfWork, IAdminService adminService) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAdminService _adminService = adminService;
        private static int lastUsedAcademicYear = GetAcademicYear(); // Track the academic year in memory
        private static int sequence = 0;
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
        public async Task<IActionResult> CreateStudentAsync(StudentFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            int currentAcademicYear = GetAcademicYear();

            if (currentAcademicYear != lastUsedAcademicYear)
            {
                sequence = 0;
                lastUsedAcademicYear = currentAcademicYear;
            }
            ++sequence;

            string GeneratedstudentId = $"{currentAcademicYear}{sequence.ToString("D4")}";

            var user = model.MapToModel();

            var newAppUser = await _adminService.CreateUser(user);

            if (!newAppUser.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, newAppUser.Error!);
                return View();
            }

            var student = new Student
            {
                NationalId = model.NationalId,
                StudentId = GeneratedstudentId
            };

            _unitOfWork.StudentRepo.Insert(student);
            _unitOfWork.Commit();

            return View();
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

            var student = new Professor
            {
                ProfessorId = model.NationalId,
                ProfessorNavigation = newAppUser.AppUser,    
                // The rest of attr depends on the front
            };

            _unitOfWork.Professors.Insert(student);
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

            var student = new TeachingAssistant
            {
                Taid = model.NationalId,
                Ta = newAppUser.AppUser,
                AssistingProfessorId  = model.AssistingProfessorId, // Depends on the front end
                AcademicDegree = model.AcademicDegree,
                DepartmentId = model.DepartmentId, // Depends on the front end
                University = model.University
            };

            _unitOfWork.TAs.Insert(student);
            _unitOfWork.Commit();

            return View();
        }

        private static int GetAcademicYear()
        {
            var currentDate = DateTime.Now;

            if (currentDate.Month >= 9)
            {
                return currentDate.Year;
            }
            else { return currentDate.Year - 1; }
        }
    }
}
