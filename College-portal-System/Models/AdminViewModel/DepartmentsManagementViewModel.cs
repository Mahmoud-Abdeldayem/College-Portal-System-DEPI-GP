using BusinessLogicLayer.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.AdminViewModel
{
    public class DepartmentsManagementViewModel
    {
        public List<DepartmentDTO>? Departments { get; set; }

        [Required]
        public string Name { get; set; } 


        [Required]
        public string Code { get; set; }

        public List<SelectListItem>? Heads { get; set; }

        public string? HeadId {get; set;}
    }
}
