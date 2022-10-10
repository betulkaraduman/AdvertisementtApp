using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.DataAccess.UnifOfWork;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Services
{
    public class AppUserRoleService:Service<AppUserRoleCreateDto,AppUserRoleUpdateDto,AppUserRoleListDto,AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleService(IMapper _mapper,IValidator<AppUserRoleCreateDto> _userRoleCreateDto,IValidator<AppUserRoleUpdateDto> _userRoleUpdateDto,IUow _uow):base(_mapper,_userRoleCreateDto,_userRoleUpdateDto,_uow)
        {

        }

    }
}
