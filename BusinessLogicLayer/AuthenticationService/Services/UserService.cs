using BusinessLogicLayer.AuthenticationService.Implementations;
using BusinessLogicLayer.DTOs.Users;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuthenticationService.Services
{
    public class UserService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork) : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;        
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private static int lastUsedAcademicYear = GetAcademicYear(); // Track the academic year in memory
        private static int sequence = 0;

        public async Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(ApplicationUserDto userForm)
        {            
            string password = userForm.Password;

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
                Role = userForm!.SelectedRole
            };

            var createUserResult = await _userManager.CreateAsync(user, password);

            if (!createUserResult.Succeeded)
                return (IsSuccess: false, AppUser: null, Error: string.Join(',', createUserResult.Errors.Select(e => e.Description)));

            //var role = _roleManager.FindByNameAsync(userForm!.SelectedRole);            

            //if (role is null)
            //    return (IsSuccess: false, AppUser: null, Error: string.Join(',', createUserResult.Errors.Select(e => e.Description)));

            //var roleId = role.Result.Id;

            //_unitOfWork.ApplicationUserRepo.AddRole(user, roleId);

            return (IsSuccess: true, AppUser: user, Error: null);
        }

        public async Task<(bool IsSucceded, string? ErrorMessage)> AdminResetPassword(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return (IsSucceded: false, ErrorMessage: "The user is not found");

            //var changePassword = await _userManager.ChangePasswordAsync();

            var removePassword = await _userManager.RemovePasswordAsync(user);

            if (!removePassword.Succeeded)
                return (IsSucceded: false, ErrorMessage: string.Join(',', removePassword.Errors.Select(e => e.Description)));

            var newPassword = await _userManager.AddPasswordAsync(user, password);

            if (!newPassword.Succeeded)
                return (IsSucceded: false, ErrorMessage: string.Join(',', newPassword.Errors.Select(e => e.Description)));

            return (IsSucceded: true, ErrorMessage: null);
        }

        public async Task<(bool IsSucceded, string? ErrorMessage)> StudentResetPassword(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return (IsSucceded: false, ErrorMessage: "The user is not found");

            var changePassword = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!changePassword.Succeeded)
                return (IsSucceded: false, ErrorMessage: string.Join(',', changePassword.Errors.Select(e => e.Description)));


            return (IsSucceded: true, ErrorMessage: null);
        }

        public (bool IsSucceded, string? ErrorMessage) CreateStudent(ApplicationUserDto model, ApplicationUser userModel)
        {

            int currentAcademicYear = GetAcademicYear();

            if (currentAcademicYear != lastUsedAcademicYear)
            {
                sequence = 0;
                lastUsedAcademicYear = currentAcademicYear;
            }
            ++sequence;

            string GeneratedstudentId = $"{currentAcademicYear}{sequence.ToString("D4")}";

            var student = new Student
            {
                NationalId = model.NationalId,
                StudentId = GeneratedstudentId,
                National = userModel,
            };

            _unitOfWork.Students.Insert(student);
            _unitOfWork.Commit();

            return (IsSucceded: true, ErrorMessage: null);
        }
        
        //public async Task<(bool IsSucceded, string? ErrorMessage)> CreateProfessorAsync(ApplicationUserDto model, ApplicationUser userModel)
        //{
        //    var prof = new Professor
        //    {
        //        ProfessorId = model.NationalId,
        //        ProfessorNavigation = newAppUser.AppUser!,
        //        DepartmentId = model.DepartmentId,
        //        EnterYear = DateTime.Now.Year,
        //        DocUni = model.DocUni,
        //        Title = model.Title,
        //        PhDat = model.PHDField,
        //    };

        //    _unitOfWork.Professors.Insert(prof);
        //    _unitOfWork.Commit();

        //    return (IsSucceded: true, ErrorMessage: null);
        //}

        //public async Task<(bool IsSucceded, string? ErrorMessage)> CreateProfessorAsync(ApplicationUserDto model, ApplicationUser userModel)
        //{
        //    var TA = new TeachingAssistant
        //    {
        //        Taid = model.NationalId,
        //        Ta = newAppUser.AppUser,
        //        AssistingProfessorId = model.AssistingProfessorId, // Depends on the front end
        //        AcademicDegree = model.AcademicDegree,
        //        DepartmentId = model.DepartmentId, // Depends on the front end
        //        University = model.University,
        //        Faculty = model.Faculty,
        //    };

        //    _unitOfWork.TAs.Insert(TA);
        //    _unitOfWork.Commit();

        //    return (IsSucceded: true, ErrorMessage: null);
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

        public Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
