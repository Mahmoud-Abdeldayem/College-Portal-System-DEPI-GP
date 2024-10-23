using BusinessLogicLayer.DTOs.TADTOs;
using BusinessLogicLayer.DTOs.Users;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuthenticationService.Implementations
{
    public interface IAdminService
    {
        Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(ApplicationUserDto userForm);
    }
}
