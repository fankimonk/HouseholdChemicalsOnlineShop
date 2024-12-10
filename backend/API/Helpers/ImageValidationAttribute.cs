using System.ComponentModel.DataAnnotations;

namespace API.Helpers
{
    public class ImageValidationAttribute : ValidationAttribute
    {
        private readonly string[] _validImageFormats = { ".jpg", ".jpeg", ".png" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
            {
                return new ValidationResult("Uploaded file is not valid.");
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!_validImageFormats.Contains(fileExtension))
            {
                return new ValidationResult($"Invalid image format. Allowed formats: {string.Join(", ", _validImageFormats)}");
            }

            return ValidationResult.Success;
        }
    }
}
