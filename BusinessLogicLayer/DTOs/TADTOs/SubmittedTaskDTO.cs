using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.TADTOs
{
    public class SubmittedTaskDTO
    {
        public string? StudentId { get; set; }

        public string SubmissionLink { get; set; } = null!;

        public DateTime SubmissionDate { get; set; }
    }
}
