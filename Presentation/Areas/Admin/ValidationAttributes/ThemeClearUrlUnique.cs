using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class ThemeClearUrlUnique : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
                  
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;

            var checkedTheme = validationContext.ObjectInstance as ThemeViewModel;

            var validator = new ValidatorsBll<Theme>();
            var result = validator.IsPropertyUnique("ClearUrlName", value.ToString(), checkedTheme.id);

            string errorMessage = this.FormatErrorMessage("clearUrlName");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult(errorMessage);

        }
    }
}