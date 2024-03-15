using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_14669.Utils
{
    public class ReleaseDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime releaseDate && releaseDate >= DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
