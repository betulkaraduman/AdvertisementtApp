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
    public class GenderService:Service<GenderCreateDto,GenderUpdateDto,GenderListDto,UserGender>,IGenderService
    {
        public GenderService(IMapper mapper,IValidator<GenderCreateDto> _createValidator,IValidator<GenderUpdateDto> _updateValidator,IUow uow):base(mapper,_createValidator,_updateValidator,uow)
        {

        }
    }
}
