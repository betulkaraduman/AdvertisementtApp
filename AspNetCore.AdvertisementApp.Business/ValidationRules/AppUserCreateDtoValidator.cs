using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AppUserCreateDtoValidator:AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(i => i.Username).NotEmpty();
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.PhoneNumber).NotEmpty();
            RuleFor(i => i.GenderId).NotEmpty();
            RuleFor(i => i.Password).NotEmpty();
        }
    }
}
