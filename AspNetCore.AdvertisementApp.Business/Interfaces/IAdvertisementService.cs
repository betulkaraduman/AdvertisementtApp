using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Dto.Interfaces;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
       Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync();
    }
}
