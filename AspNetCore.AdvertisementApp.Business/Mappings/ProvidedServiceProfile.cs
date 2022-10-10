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
    public class ProvidedServiceProfile:Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServicesCreateDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServicesListDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServicesUpdateDto, ProvidedService>().ReverseMap();
        }
    }
}
