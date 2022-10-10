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
    public class MilitaryStatusProfile:Profile
    {
        public MilitaryStatusProfile()
        {
            CreateMap<MilitaryStatusListDto, MilitaryStatus>().ReverseMap();
        }
    }
}
