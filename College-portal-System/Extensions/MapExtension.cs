using BusinessLogicLayer.DTOs.Users;
using College_portal_System.Data.Consts;
using College_portal_System.Models.UserViewModels;

namespace College_portal_System.Extensions
{
    public static class MapExtension
    {
        public static ApplicationUserDto MapToModel(this StudentFormViewModel model)
        {
            var user = new ApplicationUserDto
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                NationalId = model.NationalId,
                Password = model.Password,
                SelectedRole = AppRoles.Student,
                PhoneNumber = model.PhoneNumber,
                Picture = model.Picture,
            };

            return user;
        }

        public static ApplicationUserDto MapToModel(this ProfessorFormViewModel model)
        {
            var user = new ApplicationUserDto
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                NationalId = model.NationalId,
                Password = model.Password,
                SelectedRole = AppRoles.Professor,
                PhoneNumber = model.PhoneNumber,
                Picture = model.Picture,
            };

            return user;
        }

        public static ApplicationUserDto MapToModel(this TAFormViewModel model)
        {
            var user = new ApplicationUserDto
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                NationalId = model.NationalId,
                Password = model.Password,
                SelectedRole = AppRoles.TA,
                PhoneNumber = model.PhoneNumber,
                Picture = model.Picture,
            };

            return user;
        }
    }
}
