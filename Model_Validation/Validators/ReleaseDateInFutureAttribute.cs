using System;
using System.ComponentModel.DataAnnotations;

//create custom validation attribute
namespace CustomValidationExample.Validators
{
    public class ReleaseDateInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime releaseDate)
            {
                if (releaseDate > DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Release date must be in the future.");
            }
            return new ValidationResult("Invalid release date.");
        }
    }
}
