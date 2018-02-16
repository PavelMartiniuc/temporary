using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class SongForeignUniqueName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;

            var checkedSong = validationContext.ObjectInstance as SongForeignViewModel;

            var validator = new ValidatorsBll<SongForeign>();
            var result = validator.IsPropertyUnique("Name", value.ToString(), checkedSong.id);

            string errorMessage = this.FormatErrorMessage("name");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult(errorMessage);

        }
    }
}