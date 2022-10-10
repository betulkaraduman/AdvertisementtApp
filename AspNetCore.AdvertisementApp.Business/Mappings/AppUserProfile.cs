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
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUserListDto,AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
        }
    }
}
