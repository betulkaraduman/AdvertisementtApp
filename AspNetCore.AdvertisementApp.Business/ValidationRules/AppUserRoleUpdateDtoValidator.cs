using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AppUserRoleUpdateDtoValidator:AbstractValidator<AppUserRoleUpdateDto>
    {
        public AppUserRoleUpdateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
