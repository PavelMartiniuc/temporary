﻿using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using Gitarist.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.ValidationAttributes
{
    public class ArtistRussianClearUrlUnique : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((string)value))
                return ValidationResult.Success;
            
            var checkedArtist = validationContext.ObjectInstance as ArtistRusianViewModel;

            var validator = new ValidatorsBll<ArtistRussian>();
            var result = validator.IsPropertyUnique("ClearUrlName", value.ToString(), checkedArtist.id);

            string errorMessage = FormatErrorMessage("clearUrlName");

            if (result)
                return ValidationResult.Success;
   
            return new ValidationResult(errorMessage);

        }
    }
}