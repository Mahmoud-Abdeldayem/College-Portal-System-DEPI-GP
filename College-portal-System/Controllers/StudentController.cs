using BusinessLogicLayer.DTO;
using BusinessLogicLayer.StudentService;
using College_portal_System.Models;
using College_portal_System.Models.StudentViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College_portal_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IStudentRepo _repo;
        public StudentController(IStudentService service, IStudentRepo repo)
        {
            _service = service;
            _repo = repo;
        }
        private ProfileViewModel GetProfile(string id)
        {
            var student=_service.GetProfileById(id);
            return new ProfileViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                Gender = student.Gender, // Assuming false for null values
                Picture = student.Picture,
                StudentId = student.StudentId,
                EntryYear = student.EntryYear,
                GradYear = student.GradYear,
                CurrentState = student.CurrentState,
                CollegeState = student.CollegeState,
                CurrentYear = student.CurrentYear,
                TotalGpa = student.TotalGpa,
                HoursTaken = student.HoursTaken,
                DepartmentId = student.DepartmentId,
                DepartmentName = student.DepartmentName, // Handle potential null
                NationalId = student.NationalId
            };
        }
        private TranscriptViewModel GetTranscript(string id)
        {
            var transcript=_service.GetStudentTranscriptById(id);
            return new TranscriptViewModel
            {
                FirstName = transcript.FirstName,
                LastName = transcript.LastName,
                Picture = transcript.Picture,
                TotalGpa = transcript.TotalGpa,
                HoursTaken = transcript.HoursTaken,
                CurrentState = transcript.CurrentState,
                CurrentYear = transcript.CurrentYear,
                DepartmentName = transcript.DepartmentName,
                NationalId = transcript.NationalId,
                StudentId = transcript.StudentId,
                Gender = transcript.Gender,
                Transcripts = transcript.Transcripts
            };
        }
        private RegisterDeptsViewModels GetDepts (string id)
        {
            var depts=_service.GetDepts(id);
            return new RegisterDeptsViewModels
            {
                StudentDepartment = depts.StudentDepartment,
                Depts = depts.Depts
            };
        }
        private RegisterDeptsViewModels GetDeptData(string id)
        {
            var student=_repo.GetById(id);
            return new RegisterDeptsViewModels
            {
                StudentDepartment=student.DepartmentId,
            };
        }
        private UserViewModel GetUser(string id)
        {
            var user=_service.GetUserById(id);
            return new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Picture=user.Picture,
                Address = user.Address,
                Password = user.Password,
                Role = user.Role,
                Gender=user.Gender,
                NationalId = user.NationalId,
                Phone=user.Phone,
                Email=user.Email,
            };
        }
        private List<AvailableCoursesViewModel> GetAvailableCourses(string id)
        {
            var availableCoursesDtoList = _service.GetAvailableCourses(id);

            // Map AvailableCoursesDTO to AvailableCoursesViewModel
            var availableCoursesViewModelList = availableCoursesDtoList.Select(course => new AvailableCoursesViewModel
            {
                Name = course.Name,
                Code = course.Code,
                CourseID = (int)course.CourseID,
            }).ToList();

            return availableCoursesViewModelList;
        }
        private List<AvailableCoursesViewModel> GetRegisteredCourses(string id)
        {
            var enrollment = _service.ViewRegisteredCourses(id);
            var enrollmentList=enrollment.Select(x=>new AvailableCoursesViewModel
            {
                Name = x.Name,
                Code = x.Code,
                CourseID = (int)x.CourseID,
            }).ToList();
            return enrollmentList;
        }

        public IActionResult Index()
        {
            return View(GetUser("30308132100798"));
            
        }
        public IActionResult Profile(string id) 
        {
            return View(GetProfile(id));
        }
        public IActionResult Update(string id)
        {
            
            return View(GetUser(id));
        }
        [HttpPost]
        public IActionResult Update(string id, UserViewModel user, IFormFile? Picture)
        {
            var DataToUpdate = new UserViewDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Picture=user.Picture,
                Phone=user.Phone,
                Email=user.Email,
            };
            _service.UpdateUser(id, DataToUpdate,Picture);
            return RedirectToAction("Profile", new {id="30308132100798"});
        }
        public IActionResult RegisterDepartment(string id)
        {
            return View(GetDepts(id));
        }
        [HttpPost]
        public IActionResult RegisterDepartment(string id,RegisterDeptsViewModels depts)
        {
            var DataToUpdate = new RegisterDeptDTO
            {
                StudentDepartment=depts.StudentDepartment,
            };
            _service.RegisterDepartment(id, DataToUpdate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePass(string id, ChangePassViewModel pass)
        {
            var user = GetUser(id);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (user.Password != pass.CurrentPass)
            {
                TempData["Message1"] = "Current password is incorrect.";
                return View();
            }

            if (pass.NewPass != pass.ConfrimPass)
            {
                TempData["Message2"] = "New password and confirmation do not match.";
                return View();
            }

            var DataToUpdate = new ChangePassDTO
            {
                NewPass = pass.NewPass,
            };
            _service.ChangePass(id, DataToUpdate);
            TempData["Message"] = "Password changed successfully.";
            return RedirectToAction("Profile", new {id=user.NationalId});
        }

        public IActionResult GetTakenCourses(string id)
        {
            return View(GetTranscript(id));
        }
        public IActionResult RegisterCourses(string id)
        {
            return View(GetAvailableCourses(id));
        }
        [HttpPost]
        public IActionResult RegisterCourses(string StudentiD,int CourseId)
        {
            _service.RegisterCourses(StudentiD, CourseId);
            TempData["success"] = "Registered Successfully";
            return RedirectToAction("RegisterCourses", new {id=StudentiD});
        }
        public IActionResult ViewRegisteredCourses(string id)
        {
            return View(GetRegisteredCourses(id));
        }

    }
}
