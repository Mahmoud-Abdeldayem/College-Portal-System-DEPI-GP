using College_portal_System.Consts;
using Microsoft.AspNetCore.Identity;

namespace College_portal_System.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Student));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.TA));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Professor));
            }
        }
    }
}
