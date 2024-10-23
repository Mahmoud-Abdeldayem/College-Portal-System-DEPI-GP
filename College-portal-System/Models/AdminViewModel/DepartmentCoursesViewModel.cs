using BusinessLogicLayer.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College_portal_System.Models.AdminViewModel
{
    public class DepartmentCoursesViewModel
    {
        public int? DepartmentId { get; set; }  
        public List<SelectListItem> Departments { get; set; }

    }
}
