using AspNetCore.AdvertisementApp.Common;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult result)
        {
            List<CustomValidationError> customErrors = new List<CustomValidationError>();
            foreach (var item in result.Errors)
            {
                customErrors.Add(new CustomValidationError() {ErrorMessage=item.ErrorMessage,PropertyName=item.PropertyName });
            }
            return customErrors;
        }
    }
}
