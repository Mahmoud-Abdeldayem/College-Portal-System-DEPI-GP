using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class TranscriptDTO
    {
        public string CourseName { get; set; } 

        public string CourseCode { get; set; } = null!;

        public int Hours { get; set; }
        public decimal FinalGrade { get; set; }
        

    }
}
