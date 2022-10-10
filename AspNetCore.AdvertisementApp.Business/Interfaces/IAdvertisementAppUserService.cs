using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType types);
        Task SetStatus(int AdvertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
