using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.UI.Models;
using AutoMapper;

namespace AspNetCore.AdvertisementApp.UI.Mappings
{
    public class AdvertisementAppUserCreateModelProfile:Profile
    {
        public AdvertisementAppUserCreateModelProfile()
        {
            CreateMap<AdvertisementAppUserCreateModel, AdvertisementAppUserCreateDto>();
        }
    }
}
