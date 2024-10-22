using BusinessLogicLayer.AdminService.Implementations;
using BusinessLogicLayer.DTOs.Users;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.AdminService.Services
{
    public class AdminService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;        

        public async Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(ApplicationUserDto userForm)
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
            
    }
}
