using BusinessLogicLayer.DTOs.TADTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.ViewModels.TAViewModels
{
    public class CreateTaskViewModel
    {
        public List<SelectListItem> Courses { get; set; }
        public List<EditTaskDTO> Tasks { get; set; }

        [Required]
        public int? CourseId { get; set; }

        [Required]

        public decimal Grade { get; set; }

        [Required]

        public DateTime Deadline { get; set; }

        [Required]

        public string Content { get; set; }

        [Required]

        public string Type { get; set; }

        [Required]
        public string TaskLink { get; set; }
        public string? AssignedByTaid { get; set; }
    }
}
