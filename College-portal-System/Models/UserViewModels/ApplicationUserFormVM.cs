using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.UserViewModels
{
    public class ApplicationUserFormVM
    {
        [Required(), MaxLength(50)]
        public string FirstName { get; set; }
    }
}
