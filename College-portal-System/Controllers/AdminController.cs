using BusinessLogicLayer.AuthenticationService.Implementations;
using BusinessLogicLayer.AuthenticationService.Services;
using College_portal_System.Data.Consts;
using College_portal_System.Extensions;
using College_portal_System.ViewModels.UserViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace College_portal_System.Controllers
{
    public class AdminController(BusinessLogicLayer.AdminService.Services.AdminService adminService, IUnitOfWork unitOfWork) : Controller
    {
        private readonly BusinessLogicLayer.AdminService.Services.AdminService _adminService = adminService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;        

        //------------------------------<End of private fields>-----------------------------------
        public IActionResult Index()
        {
            ViewBag.Name = "Admin!!";
            return View();
        }

        #region Students Views
        public IActionResult Students()
        {
            return View();
        }

        public IActionResult StudentIndex()
        {
            var students = _unitOfWork.StudentRepo.GetAll();

            if (students is null)
                return NotFound();

            var studentViews =  students.MapToViewModel();

            return View(studentViews);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            var studentViewModel = new ApplicationUserFormVM();

            return View(studentViewModel);
        }
        #endregion

        #region TeachingAssisstants Views
        public IActionResult TeachingAssisstantIndex()
        {
            var teachingAssisstants = _unitOfWork.TAs.GetAll().ToList();

            if (teachingAssisstants is null)
                return NotFound();

            var teachingAssisstantstViews = teachingAssisstants.MapToViewModel();

            return View(teachingAssisstantstViews);
        }

        [HttpGet]
        public IActionResult CreateTeachingAssisstant()
        {
            var ViewModel = new TAFormViewModel();

            return View(ViewModel);
        }

        #endregion

        #region Professor Views
        public IActionResult ProfessorIndex()
        {
            var profs = _unitOfWork.Professors.GetAll().ToList();

            if (profs is null)
                return NotFound();

            var profsViews = profs.MapToViewModel();

            return View(profsViews);
        }

        [HttpGet]
        public IActionResult CreateProfessor()
        {
            var ViewModel = new ProfessorFormViewModel();

            return View(ViewModel);
        }
        #endregion

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
                Departments = GetAllDepartmentsSelectList(),
                PrerequisiteCourses = GetAllCoursesSelectList(),
            };
            viewModel.PrerequisiteCourses.Insert(0 , new SelectListItem() { Value = "" , Text = "No Prerequisite" });
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCourse(AddCourseViewModel newCourse)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddCourse(new AddCourseDTO()
                {
                    Name = newCourse.CourseName,
                    Code = newCourse.CourseCode,
                    Semseter = newCourse.Semester,
                    Hours = newCourse.Hours,
                    DepartmentId = newCourse.DepartmentId,
                    PrerequisiteCourseId = newCourse.PrerequisiteCourseId,
                    CourseLevel = newCourse.Level
                });
                return RedirectToAction("Courses");
            }
            else 
            { 
                newCourse.Departments = GetAllDepartmentsSelectList();
                newCourse.PrerequisiteCourses = GetAllCoursesSelectList();
                newCourse.PrerequisiteCourses.Insert(0 , new SelectListItem() { Value = "" , Text = "No Prerequisite" });

                return View(newCourse);
            }
        }

        [HttpGet]
        public IActionResult ShowAllCourses()
        {
            var viewModel = new DepartmentCoursesViewModel()
            {
                Departments = GetAllDepartmentsSelectList() // All Existed Departments in Database
            };
            viewModel.Departments.Add(new SelectListItem() { Value = "0" , Text = "All Departments"}); // For selecting all courses without specific dapartment
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetDepartmentCourses(int departmentId)
        {
            if (departmentId == 0) // Get all courses without specific department
            {
                var courses = _adminService.GetAllCourses();
                return Json(courses);    
            }
            else // Get all department related courses
            {
                var courses = _adminService.GetCoursesByDepartment(departmentId);
                return Json(courses);   
            }
        }
        //----------------------------------------<Departments>---------------------------------------

        [HttpGet]
        public IActionResult Departments()
        {
            var viewModel = new DepartmentsManagementViewModel()
            {
                Departments = _adminService.GetDepartments() ,
                Heads = GetAllProfessorsSelectList()
            };
            viewModel.Heads.Insert(0, new SelectListItem()
            {
                Value = "" , 
                Text = "Without Head"
            });
            return View(viewModel); 
        }

        [HttpPost("/Departments/AddDepartment")]
        public IActionResult AddDepartment(DepartmentsManagementViewModel newDepartmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddDepartment(new DepartmentDTO
                {
                    Name = newDepartmentViewModel.Name,
                    Code = newDepartmentViewModel.Code,
                    HeadId = newDepartmentViewModel.HeadId
                });
                return RedirectToAction("Departments");
            }
            return View("Departments" , newDepartmentViewModel);
        }

        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                _adminService.DeleteDepartment(id);
                return RedirectToAction("Departments");
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        //----------------------------------------<Students>------------------------------------------
        public IActionResult EditStudent()
        {
            return View();
        }       

        #region Overloads
        private List<SelectListItem> GetAllCoursesSelectList()
        {
            return _adminService.GetCourses().Select(c => new SelectListItem()
            {
                Value = c.CourseId.ToString(),
                Text = c.Name
            }).ToList();
        }

        private List<SelectListItem> GetAllDepartmentsSelectList()
        {
            return _adminService.GetDepartments().Select(d => new SelectListItem()
            {
                Value = d.DepartmentId.ToString(),
                Text = d.Name
            }).ToList();
        }

        private List<SelectListItem> GetAllProfessorsSelectList()
        {
            return _adminService.GetAllProfessors().Select(p => new SelectListItem()
            {
                Value = p.ProfessorId,
                Text = $"{p.ProfessorNavigation.FirstName} {p.ProfessorNavigation.LastName}",
            }).ToList();
        }
        #endregion
    }
}
