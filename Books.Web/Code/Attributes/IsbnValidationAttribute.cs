using System.ComponentModel.DataAnnotations;
using Autofac;
using Books.BL.Interfaces.Validation;
using Books.Web.DI;

namespace Books.Web.Code.Attributes
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
	        var isbnValidator = DiConfig.Container.ResolveNamed<IValidator>("ISBN");

			var strValue = value as string;

			return isbnValidator.IsValid(strValue, out var errorMessage)
				? ValidationResult.Success
				: new ValidationResult(errorMessage);
		}
    }
}
