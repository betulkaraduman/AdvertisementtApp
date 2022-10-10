using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreatWithRole(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> LoginUser(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int UserId);


        }
}
