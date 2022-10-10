using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class GenderUpdateDtoValidator:AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(i => i.Definition).NotEmpty();
        }
    }
}
