using BusinessLogicLayer.DTOs.Users;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuthenticationService.Implementations
{
    public interface IUserService
    {        
        Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(ApplicationUserDto userForm);
        Task<(bool IsSucceded, string? ErrorMessage)> AdminResetPassword(string userId, string password);
        Task<(bool IsSucceded, string? ErrorMessage)> StudentResetPassword(string userId, string currentPassword, string newPassword);
        (bool IsSucceded, string? ErrorMessage) CreateStudent(ApplicationUserDto model, ApplicationUser userModel);
    }
}
