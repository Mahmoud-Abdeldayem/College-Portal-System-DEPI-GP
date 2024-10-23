using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.StudentViewModels
{
    public class ChangePassViewModel
    {
        [Required(ErrorMessage ="You Must Enter Your Current Password")]
        public string CurrentPass { get; set; }
        [Required(ErrorMessage = "You Must Enter Your New Password")]
        public string NewPass { get; set; }
        [Required(ErrorMessage = "You Must Confirm Your Password")]
        public string ConfrimPass { get; set; }
    }
}
