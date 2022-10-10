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
    public class GenderProfile:Profile
    {
        public GenderProfile()
        {
            CreateMap<UserGender, GenderCreateDto>().ReverseMap();
            CreateMap<UserGender, GenderUpdateDto>().ReverseMap();
            CreateMap<UserGender, GenderListDto>().ReverseMap();
        }
    }
}
