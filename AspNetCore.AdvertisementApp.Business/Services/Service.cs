using AspNetCore.AdvertisementApp.Business.Extensions;
using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.DataAccess.UnifOfWork;
using AspNetCore.AdvertisementApp.Dto.Interfaces;
using AspNetCore.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T> where CreateDto : IDto, new() where UpdateDto : IUpdateDto, new() where ListDto : IDto, new() where T : BaseEntity, new()
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createValidator;
        private readonly IValidator<UpdateDto> _updateValidator;
        //private readonly IValidator<ListDto> _listValidator;
        private readonly IUow _uow;
        public Service(IMapper mapper, IValidator<CreateDto> createValidator, IValidator<UpdateDto> updateValidator, IUow uow)
        {
            _uow = uow;
            _createValidator = createValidator;
            //_listValidator = listValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }
        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createValidator.Validate(dto);
            if (result.IsValid)
            {
                var createEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().Add(createEntity);
                await _uow.SaveChanges();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }

            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var result = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(result);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        //public async Task<IResponse<ListDto>> GetByIdAsync(int Id)
        //{
        //    var result = await _uow.GetRepository<T>().GetByFilter(x => x.Id == Id);
        //    if (result != null)
        //    {
        //        var dto = _mapper.Map<ListDto>(result);
        //        return new Response<ListDto>(ResponseType.Success, dto);
        //    }
        //    return new Response<ListDto>(ResponseType.NotFound, $"{Id} not found");
        //}

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int Id)
        {
            var result = await _uow.GetRepository<T>().GetByFilter(x => x.Id == Id);
            if (result != null)
            {
                var dto = _mapper.Map<IDto>(result);
                return new Response<IDto>(ResponseType.Success, dto);
            }
            return new Response<IDto>(ResponseType.NotFound, $"{Id} not found");
        }

        public async Task<IResponse> RemoveAsycn(int Id)
        {
            var data = await _uow.GetRepository<T>().GetById(Id);
            if (data == null)

                return new Response(ResponseType.NotFound, $"{Id} not found");
            _uow.GetRepository<T>().Remove(data); await _uow.SaveChanges();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var validate = _updateValidator.Validate(dto);
            if (validate.IsValid)
            {
                var lastValue = await _uow.GetRepository<T>().GetById(dto.Id);
                var updateEntity = _mapper.Map<T>(dto);
                if (lastValue == null)
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} not found");

                _uow.GetRepository<T>().Update(updateEntity, lastValue); await _uow.SaveChanges();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>(dto,validate.ConvertToCustomValidationError());
        }
    }
}
