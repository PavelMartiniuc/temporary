using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using Gitarist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class ThemeUniqueName : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;

            var checkedTheme = validationContext.ObjectInstance as ThemeViewModel;

            var validator = new ValidatorsBll<Theme>();
            var result = validator.IsPropertyUnique("Name", value.ToString(), checkedTheme.id);

            string errorMessage = this.FormatErrorMessage("name");

            if (result)
                return ValidationResult.Success;
            
            return new ValidationResult(errorMessage);
            
        }
    }
}