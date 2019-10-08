using System.ComponentModel.DataAnnotations;
using Books.Web.Validation;

namespace Books.Web.Attributes
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strValue = value as string;

            return IsbnValidator.IsValid(strValue, out var errorMessage)
	            ? ValidationResult.Success
	            : new ValidationResult(errorMessage);
        }
    }
}