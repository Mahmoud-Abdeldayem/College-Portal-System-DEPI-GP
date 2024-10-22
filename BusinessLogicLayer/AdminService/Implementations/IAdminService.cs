using BusinessLogicLayer.DTOs.TADTOs;
using College_portal_System.Models.AdminViewModels;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AdminService.Implementations
{
    public interface IAdminService
    {
        Task<(bool IsSuccess, ApplicationUser? AppUser, string? Error)> CreateUser(RegisterFormViewModel userForm);
    }
}
