using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.UI.Extentions;
using AspNetCore.AdvertisementApp.UI.Models;
using AspNetCore.AdvertisementApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AspNetCore.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _map;
        private readonly IValidator<UserCreateModel> _userCreateValidator;
        private readonly IValidator<AppUserLoginDto> _userLoginDto;
        private readonly IAppUserService _appUserService;
        public AccountController(IGenderService genderService, IMapper map, IValidator<UserCreateModel> userCreateValidator, IAppUserService appUserService, IValidator<AppUserLoginDto> userLoginDto)
        {
            _appUserService = appUserService;
            _userCreateValidator = userCreateValidator;
            _map = map;
            _userLoginDto = userLoginDto;
            _genderService = genderService;
        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel();
            model.Genders = new SelectList(response.Data, "Id", "Definition");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateValidator.Validate(model);
            if (result.IsValid)
            {
                var userDto = _map.Map<AppUserCreateDto>(model);
                //var res =await _appUserService.CreateAsync(userDto);
                var res = await _appUserService.CreatWithRole(userDto, (int)RoleType.Member);
                return this.ResponseRedirectToAction(res, "Login");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }
        public IActionResult Login()
        {
            return View(new AppUserLoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto dto)
        {

            var validationResult = _userLoginDto.Validate(dto);

            if (validationResult.IsValid)
            {
                var response = await _appUserService.LoginUser(dto);
                if (response.ResponseType == Common.ResponseType.Success)
                {
                    var claims = new List<Claim>();

                    var roles = await _appUserService.GetRolesByUserIdAsync(response.Data.Id);
                    if (roles.ResponseType == Common.ResponseType.Success)
                    {
                        foreach (var item in roles.Data)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item.Definition));
                        }
                    }

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, response.Data.Id.ToString()));
                    var claimsIdentity = new ClaimsIdentity(
                       claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = dto.RememberMe,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("Index", "Home");


                }
                ModelState.AddModelError("", response.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
