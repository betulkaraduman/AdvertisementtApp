using AspNetCore.AdvertisementApp.Business.Services;
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
    public class AdvertisementProfile:Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<AdvertisementCreateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementUpdateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementListDto, Advertisement>().ReverseMap();
        }

    }
}
