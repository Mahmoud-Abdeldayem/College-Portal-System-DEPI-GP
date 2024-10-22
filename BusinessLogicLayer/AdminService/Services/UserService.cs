using BusinessLogicLayer.AdminService.Implementations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AdminService.Services
{
    public class UserService(UserManager<ApplicationUser> userManager) : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<(bool IsSucceded, string? ErrorMessage)> ResetPassword(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return (IsSucceded: false, ErrorMessage: "The user is not found");

            //var changePassword = await _userManager.ChangePasswordAsync();

            var removePassword = await _userManager.RemovePasswordAsync(user);

            if (!removePassword.Succeeded)
                return (IsSucceded: false, ErrorMessage: "There is something wrong, Please try again!!!");

            var newPassword = await _userManager.AddPasswordAsync(user, password);

            if (!removePassword.Succeeded)
                return (IsSucceded: false, ErrorMessage: "There is something wrong, Please try again!!!");

            return (IsSucceded: true, ErrorMessage: null);
        }
    }
}
