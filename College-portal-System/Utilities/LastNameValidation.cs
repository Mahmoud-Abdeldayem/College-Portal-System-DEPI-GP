using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Utilities
{
    public class LastNameValidation : ValidationAttribute
    {
        private string _lastName;
        private string _errorMessage;
        public LastNameValidation() 
        {
        }
    }
}
