using System.ComponentModel.DataAnnotations;
using Books.Web.Logic.Validation;

namespace Books.Web.Attributes
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strValue = value as string;

            string errorMessage;
            if (!IsbnValidator.IsValid(strValue, out errorMessage))
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}