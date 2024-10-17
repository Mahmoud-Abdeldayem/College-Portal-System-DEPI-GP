using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Utilities.Validations
{
    public class ImageValidation : ValidationAttribute
    {
        private readonly string[] _acceptedExtentions = new string[] {".jpg" , ".png" , ".jpeg"};

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var imageFile = value as IFormFile;
            if (imageFile != null)
            {
                var imageExtention = Path.GetExtension(imageFile.FileName).ToLower();
                if (! _acceptedExtentions.Contains(imageExtention))
                {
                    return new ValidationResult("Image File should be in JPG or PNG or JPEG format");
                }
            }
            return ValidationResult.Success;
        }
    }
}
