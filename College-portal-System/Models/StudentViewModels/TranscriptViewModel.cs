using BusinessLogicLayer.DTO;

namespace College_portal_System.Models.StudentViewModels
{
    public class TranscriptViewModel
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
        public bool? Gender { get; set; }
        public List<TranscriptDTO> Transcripts { get; set; } = new List<TranscriptDTO>();
    }
}
