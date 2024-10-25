namespace College_portal_System.Models.StudentViewModels
{
    public class TaskViewModel
    {
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public DateTime? DeadLine { get; set; }
        public string? Content { get; set; }
        public string? Type { get; set; }
        public string? PublishedBy { get; set; }
        public string? PublisherName { get; set; }
        public string? TaskDetailsLink { get; set; }
        public decimal? Grade { get; set; }
    }
}
