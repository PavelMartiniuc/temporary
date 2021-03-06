﻿using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class ArtistForeignUniqueName : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;

            var checkedArtist = validationContext.ObjectInstance as ArtistForeignViewModel;

            var validator = new ValidatorsBll<ArtistForeign>();
            var result = validator.IsPropertyUnique("Name", value.ToString(), checkedArtist.id);

            string errorMessage = this.FormatErrorMessage("name");

            if (result)
                return ValidationResult.Success;
            
            return new ValidationResult(errorMessage);

        }
    }
}