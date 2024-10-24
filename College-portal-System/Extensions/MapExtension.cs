using BusinessLogicLayer.DTOs.Users;
using College_portal_System.Data.Consts;
using College_portal_System.ViewModels.UserViewModels;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace College_portal_System.Extensions
{
    public static class MapExtension
    {
        public static ApplicationUserDto MapToModel(this ApplicationUserFormVM model)
        {
            var user = new ApplicationUserDto
            {
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                NationalId = model.NationalId,
                Password = model.NationalId,
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
                Password = model.NationalId,
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
                Password = model.NationalId,
                SelectedRole = AppRoles.TA,
                PhoneNumber = model.PhoneNumber,
                Picture = model.Picture,
            };

            return user;
        }
        public static IEnumerable<StudentOverviewModel> MapToViewModel(this List<Student> modelList)
        {
            var viewModelList = modelList.Select(m => new StudentOverviewModel
            {
                Students = modelList
            });

            return viewModelList;
        }
        //public static CityFormViewModel? InitialCityForm(CityFormViewModel? model = null)
        //{
        //    CityFormViewModel cityFormView = model is null ? new CityFormViewModel() : model;
        //    var Governorates = _context.Governorates.Where(c => !c.IsDeleted).OrderBy(c => c.Name).ToList();

        //    cityFormView.Governorate = _mapper.Map<IEnumerable<SelectListItem>>(Governorates);

        //    return cityFormView;
        //}
    }
}
