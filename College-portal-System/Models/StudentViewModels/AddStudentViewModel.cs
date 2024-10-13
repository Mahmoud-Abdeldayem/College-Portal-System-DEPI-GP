using College_portal_System.Utilities;
using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.StudentViewModels
{
    public class AddStudentViewModel
    {

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }    

        [Required]
        [MaxLength(14 , ErrorMessage = "The Egyptian National ID Consists of 14 digit")]
        [MinLength(14 , ErrorMessage = "The Egyptian National ID Consists of 14 digit")]
        public string NationalID { get; set; }

        [Required]
        [EmailAddress]
        public string  Email { get; set; }

        [Required]
        public Gender gender {get; set;} 

    }
}
