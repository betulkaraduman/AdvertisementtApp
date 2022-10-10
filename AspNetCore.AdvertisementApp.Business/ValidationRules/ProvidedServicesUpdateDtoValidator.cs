using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServicesUpdateDtoValidator:AbstractValidator<ProvidedServicesUpdateDto>
    {
        public ProvidedServicesUpdateDtoValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.ImagePath).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
        }
    }
}
