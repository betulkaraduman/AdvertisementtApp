using AspNetCore.AdvertisementApp.Business.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>()
            {
               new ProvidedServiceProfile(),
               new AdvertisementProfile(),
               new AppUserProfile(),
               new AppRoleProfile(),
               new GenderProfile(),
               new AppUserRoleProfile(),
               new AdvertisementAppUserProfile(),
               new AdvertisementUserStatusProfile(),
               new MilitaryStatusProfile()
            };
        }
    }
}
