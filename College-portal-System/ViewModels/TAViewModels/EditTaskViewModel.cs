using System.ComponentModel.DataAnnotations;

namespace College_portal_System.ViewModels.TAViewModels
{
    public class EditTaskViewModel
    {
        public int TaskId { get; set; }

        [Required]
        public string TaskContent { get; set; }

        [Required]
        public string TaskLink { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public decimal Grade {  get; set; }
    }
}
