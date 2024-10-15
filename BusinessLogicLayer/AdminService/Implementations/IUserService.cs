using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AdminService.Implementations
{
    public interface IUserService
    {

        Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
