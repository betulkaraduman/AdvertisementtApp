using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService:IService<ProvidedServicesCreateDto,ProvidedServicesUpdateDto,ProvidedServicesListDto,ProvidedService>
    {
    }
}
