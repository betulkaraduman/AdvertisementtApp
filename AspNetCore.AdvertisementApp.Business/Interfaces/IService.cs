using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.DataAccess.Interfaces;
using AspNetCore.AdvertisementApp.Dto.Interfaces;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto,T> where CreateDto : IDto, new() where UpdateDto : IUpdateDto, new() where ListDto : IDto, new() where T:BaseEntity, new()
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);

        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        //Task<IResponse<ListDto>> GetByIdAsync(int Id);

        Task<IResponse> RemoveAsycn(int Id);

        Task<IResponse<List<ListDto>>> GetAllAsync();



    }
}
