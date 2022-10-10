using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.DataAccess.UnifOfWork;
using AspNetCore.AdvertisementApp.Dto;
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
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IUow _Uow;
        public AdvertisementService(IMapper mapper,
        IValidator<AdvertisementCreateDto> _createValidator,
        IValidator<AdvertisementUpdateDto> _updateValidator,
        IUow _uow) : base(mapper, _createValidator, _updateValidator, _uow)
        {
            _mapper = mapper;
            _Uow = _uow;

        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
        {
            var data=await _Uow.GetRepository<Advertisement>().GetAllAsync(i => i.Status, OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
      
        }
    }
}
