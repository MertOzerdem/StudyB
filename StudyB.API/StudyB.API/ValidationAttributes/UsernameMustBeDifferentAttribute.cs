using StudyB.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.ValidationAttributes
{
    public class UsernameMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (UserForCreationDto)validationContext.ObjectInstance;

            if (user.UserName == user.FirstName || user.UserName == user.LastName)
            {
                return new ValidationResult(
                    "Firstname or Lastname cannot be same with Username.",
                    new[] { "UserForCreationDto" });
            }

            return ValidationResult.Success;
        }

        // USE IF YOU WANT CUSTOM ERROR MESSAGE RETURN FOR THİS ATTRİBUTE
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var user = (UserForCreationDto)validationContext.ObjectInstance;

        //    if (user.UserName == user.FirstName || user.UserName == user.LastName)
        //    {
        //        return new ValidationResult(
        //            ErrorMessage,
        //            new[] { "UserForCreationDto" });
        //    }

        //    return ValidationResult.Success;
        //}
    }
}
