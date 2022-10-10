using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.UI.Extentions;
using AspNetCore.AdvertisementApp.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AspNetCore.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementAppUserService _advertisementUserService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AdvertisementController(IAdvertisementAppUserService advertisementUserService, IAppUserService appUserService, IMapper mapper,IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
            _advertisementUserService = advertisementUserService;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Apply(int AdvertisementId)
        {
            int UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);
            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto()
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)

                });
            }
            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
            return View(new AdvertisementAppUserCreateModel
            {
                AppUserId = UserId,
                AdvertisementId = AdvertisementId
            });
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Apply(AdvertisementAppUserCreateModel model)
        {
            if (model.CvPath != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvPath.FileName);

                var streamPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(streamPath, FileMode.Create);
                await model.CvPath.CopyToAsync(stream);

            }
            var modelDto = _mapper.Map<AdvertisementAppUserCreateDto>(model);

            var response = await _advertisementUserService.CreateAsync(modelDto);
            if (response.ResponseType == Common.ResponseType.ValidationError)
            {

                foreach (var item in response.customValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                int UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);
                ViewBag.GenderId = userResponse.Data.GenderId;
                var items = Enum.GetValues(typeof(MilitaryStatusType));
                var list = new List<MilitaryStatusListDto>();
                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto()
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item)

                    });
                }
                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
                return View(model);
            }
            return RedirectToAction("HumanResource","Home");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> JobList()
        {
            var result = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Appied);
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList(AdvertisementAppUserStatusType type)
        {
            var result = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Interview);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectList(AdvertisementAppUserStatusType type)
        {
            var result = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Negative);
            return View(result);
        }


        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> setStatus(int AdvertisementAppUserId,AdvertisementAppUserStatusType type)
        {
           await _advertisementUserService.SetStatus(AdvertisementAppUserId, type);
            return RedirectToAction("JobList","Advertisement");
        }
    }
}
