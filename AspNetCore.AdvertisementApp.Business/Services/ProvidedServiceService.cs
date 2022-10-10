using AspNetCore.AdvertisementApp.Business.Interfaces;
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
    public class ProvidedServiceService : Service<ProvidedServicesCreateDto, ProvidedServicesUpdateDto, ProvidedServicesListDto, ProvidedService>, IProvidedServiceService
    {

        public ProvidedServiceService(IMapper _mapper,
        IValidator<ProvidedServicesCreateDto> _createValidator,
        IValidator<ProvidedServicesUpdateDto> _updateValidator,
        IUow _uow) : base(_mapper, _createValidator, _updateValidator, _uow)
        {

        }
    }
}
