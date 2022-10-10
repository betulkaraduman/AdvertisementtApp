using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.UI.Models;
using AutoMapper;

namespace AspNetCore.AdvertisementApp.UI.Mappings
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
