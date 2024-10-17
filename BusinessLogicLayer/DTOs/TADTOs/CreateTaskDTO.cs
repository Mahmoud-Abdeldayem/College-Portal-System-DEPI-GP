using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.TADTOs
{
    public class CreateTaskDTO
    {
        public int? CourseId { get; set; }

        public string CourseName { get; set; }
        public decimal Grade { get; set; }

        public DateTime Deadline { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public string? AssignedByTaid { get; set; }

        public string TaskLink { get; set; }

    }
}
