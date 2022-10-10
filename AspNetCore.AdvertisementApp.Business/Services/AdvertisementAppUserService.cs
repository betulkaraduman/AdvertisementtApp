using AspNetCore.AdvertisementApp.Business.Extensions;
using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common;
using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.DataAccess.UnifOfWork;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createValidator;
        public AdvertisementAppUserService(IUow uow, IMapper mapper, IValidator<AdvertisementAppUserCreateDto> createValidator)
        {
            _createValidator = createValidator;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var validateResult = _createValidator.Validate(dto);
            if (validateResult.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementUser>().GetByFilter(i => i.AppUserId == dto.AppUserId && i.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var advertisementUser = _mapper.Map<AdvertisementUser>(dto);
                    await _uow.GetRepository<AdvertisementUser>().Add(advertisementUser);
                    await _uow.SaveChanges();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> errors = new List<CustomValidationError>()
                {
                    new CustomValidationError{ErrorMessage="This user already applied this advertisement",PropertyName=""}
                };
                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, validateResult.ConvertToCustomValidationError());

        }
        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType types)
        {
            var query = _uow.GetRepository<AdvertisementUser>().getQuery();
            var list = await query.Include(i => i.Advertisement).Include(i => i.AdvertisementUserStatus).Include(i => i.MilitaryStatus).Include(i => i.AppUser).ThenInclude(i => i.UserGender).Where(i => i.AdvertisementUserStatusId == (int)types).ToListAsync();
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }
        public async Task SetStatus(int AdvertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            //var advertisementAppUser =await _uow.GetRepository<AdvertisementUser>().GetById(AdvertisementAppUserId);
            //var advertisementAppUserChanged =await _uow.GetRepository<AdvertisementUser>().GetById(AdvertisementAppUserId);
            //advertisementAppUserChanged.MilitaryStatusId=(int)type;
            //advertisementAppUserChanged.Id = AdvertisementAppUserId;

            var query = _uow.GetRepository<AdvertisementUser>().getQuery();

            var entity =await query.SingleOrDefaultAsync(i => i.Id == AdvertisementAppUserId);
            entity.AdvertisementUserStatusId = (int)type;
            await _uow.SaveChanges();

        }
    }
}
