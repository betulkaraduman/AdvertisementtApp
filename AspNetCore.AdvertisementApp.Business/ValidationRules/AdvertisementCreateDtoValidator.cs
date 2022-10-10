using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementCreateDtoValidator:AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(i => i.Title).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();
        }
    }
}
