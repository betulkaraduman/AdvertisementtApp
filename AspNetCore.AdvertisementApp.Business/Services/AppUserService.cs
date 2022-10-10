using AspNetCore.AdvertisementApp.Business.Extensions;
using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common;
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
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IValidator<AppUserCreateDto> _createValidator;
        private readonly IValidator<AppUserLoginDto> _loginValidator;
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto> _updateValidator, IUow uow, IValidator<AppUserLoginDto> loginValidator) : base(mapper, createValidator, _updateValidator, uow)
        {
            _createValidator = createValidator;
            _uow = uow;
            _mapper = mapper;
            _loginValidator = loginValidator;
        }


        public async Task<IResponse<AppUserCreateDto>> CreatWithRole(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var appUser = _mapper.Map<AppUser>(dto);
                appUser.AppUserRoles = new List<AppUserRole>();
                appUser.AppUserRoles.Add(new AppUserRole()
                {

                    User = appUser,
                    RoleId = roleId
                });

                await _uow.GetRepository<AppUser>().Add(appUser);
                await _uow.SaveChanges();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());

        }


        public async Task<IResponse<AppUserListDto>> LoginUser(AppUserLoginDto dto)
        {
            var validatiobResult = _loginValidator.Validate(dto);
            if (validatiobResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetAllAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null && user.Count > 0)
                {
                    //var appUserDto = _mapper.Map<AppUserListDto>(user);

                    var appUserDto = new AppUserListDto()
                    {
                        Username = user[0].Username,
                        Password = user[0].Password,
                        Id = user[0].Id,
                    };

                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.ValidationError, "Username or password error");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Username or password cannot be empty");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int UserId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.UserId == UserId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "Role can not found");
            }

            // var appRoleDto = _mapper.Map<List<AppRoleListDto>>(roles);
            List<AppRoleListDto> appRoleListDtos = new List<AppRoleListDto>();
            foreach (var item in roles)
            {
                appRoleListDtos.Add(new AppRoleListDto()
                {
                    Id = item.Id,
                    Definition = item.RoleName
                });
            }

            return new Response<List<AppRoleListDto>>(ResponseType.Success, appRoleListDtos);


        }

        //public async Task<IResponse<AppUserListDto>> GetUserWithGender(int UserId)
        //{
        //    //var user=_uow.GetRepository<AppUser>().GetById(UserId);
        //    //if (user != null)
        //    //{
        //    //    var gender=_uow.GetRepository<UserGender>().GetByFilter(i=>i.Id==user.Da)
        //    //}



        //    return new Response<AppUserListDto>("", "");
        //}
    }
}
