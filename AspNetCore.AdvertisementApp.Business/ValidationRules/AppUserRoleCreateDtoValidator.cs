using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AppUserRoleCreateDtoValidator:AbstractValidator<AppUserRoleCreateDto>
    {
        public AppUserRoleCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
