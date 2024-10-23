﻿using BusinessLogicLayer.AuthenticationService.Implementations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuthenticationService.Services
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
    }
}