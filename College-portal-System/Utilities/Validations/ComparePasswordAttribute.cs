using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Utilities.Validations
{
    /// <summary>
    /// Compares between 2 strings especaily 2 passwords
    /// </summary>
    public class ComparePasswordAttribute : ValidationAttribute
    {
        private readonly string _comparedPassword; 
        public ComparePasswordAttribute(string password) 
        {
            _comparedPassword = password;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentPassword = value?.ToString();
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparedPassword);
            var comparisonValue = propertyInfo.GetValue(validationContext.ObjectInstance)?.ToString();
            if (currentPassword != comparisonValue)
            {
                return new ValidationResult("The Re-entered password doesn't match the first one");
            }
            return ValidationResult.Success;
        }
    }
}
//var currentValue = value?.ToString();

//

//if (currentValue != comparisonValue)
//{
//    return new ValidationResult(ErrorMessage ?? "The passwords do not match.");
//}