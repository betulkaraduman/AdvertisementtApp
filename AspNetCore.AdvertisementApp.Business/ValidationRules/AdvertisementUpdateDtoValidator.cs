using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementUpdateDtoValidator:AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
        }
    }
}
