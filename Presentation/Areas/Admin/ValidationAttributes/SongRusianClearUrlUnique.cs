using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class SongRusianClearUrlUnique : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;

            var checkedSong = validationContext.ObjectInstance as SongRusianViewModel;

            var validator = new ValidatorsBll<SongRussian>();
            var result = validator.IsPropertyUnique("ClearUrlName", value.ToString(), checkedSong.id);

            string errorMessage = this.FormatErrorMessage("clearUrlName");

            if (result)
                return ValidationResult.Success;
            
            return new ValidationResult(errorMessage);
            
        }
    }
}