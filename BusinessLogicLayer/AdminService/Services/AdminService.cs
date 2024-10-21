using BusinessLogicLayer.AdminService.Implementations;
using College_portal_System.Models.AdminViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.AdminService.Services
{
    public class AdminService(/*ApplicationDbContext context*/,IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private static int lastUsedAcademicYear = GetAcademicYear(); // Track the academic year in memory
        private static int sequence = 0;

        public async Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(RegisterFormViewModel userForm)
        {
            var user = new ApplicationUser
            {
                Email = userForm.Email,
                UserName = userForm.Email,
                EmailConfirmed = true,
                NationalId = userForm.NationalId,
                FirstName = userForm.FirstName,
                LastName = userForm.LastName,
                PhoneNumber = userForm.PhoneNumber,
                Address = userForm.Address,
                Gender = userForm.Gender,
                Picture = userForm?.Picture,
            };

            var createUserResult = await _userManager.CreateAsync(user, userForm.Password);

            if (!createUserResult.Succeeded)
                return (IsSuccess: false, AppUser: null, Error: string.Join(',', createUserResult.Errors.Select(e => e.Description)));

            var addToRoleResult = await _userManager.AddToRoleAsync(user, userForm.SelectedRole);

            if (!addToRoleResult.Succeeded)
                return (IsSuccess: false, AppUser: null, Error: string.Join(',', addToRoleResult.Errors.Select(e => e.Description)));

            return (IsSuccess: true, AppUser: user, Error: null);
        }
        //public async Task<Student> CreateStudentAsync(StudentFormViewModel model)
        //{
        //    int currentAcademicYear = GetAcademicYear();
            
        //    if (currentAcademicYear != lastUsedAcademicYear)
        //    {                
        //        sequence = 0;
        //        lastUsedAcademicYear = currentAcademicYear;
        //    }            

        //    ++sequence;
            
        //    string GeneratedstudentId = $"{currentAcademicYear}{sequence.ToString("D4")}";
            
        //    var student = new Student
        //    {
        //        //Add Student Data to Student Table
        //    };

        //    student.StudentId = GeneratedstudentId;
        //    await _context.Student.Update(student);
        //    _context.SaveChanges();


        //    return student;

        //}
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
