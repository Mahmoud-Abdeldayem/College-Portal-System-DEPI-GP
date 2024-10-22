using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class StudentTranscriptDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Picture { get; set; }
        public string? NationalId { get; set; }
        public string StudentId { get; set; }
        public decimal? TotalGpa { get; set; }
        public int HoursTaken { get; set; }
        public bool? CurrentState { get; set; }
        public short? CurrentYear { get; set; } 
        public string? DepartmentName { get; set; } = string.Empty; 
        public bool? Gender {  get; set; }
        public List<TranscriptDTO> Transcripts { get; set; } = new List<TranscriptDTO>();
    }
}
