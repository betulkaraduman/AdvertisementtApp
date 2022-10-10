using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Mappings
{
    public class AppUserRoleProfile:Profile
    {
        public AppUserRoleProfile()
        {
            CreateMap<AppUserRole, AppUserRoleCreateDto>().ReverseMap();
            CreateMap<AppUserRole, AppUserRoleUpdateDto>().ReverseMap();
            CreateMap<AppUserRole, AppUserRoleListDto>().ReverseMap();
        }
    }
}
