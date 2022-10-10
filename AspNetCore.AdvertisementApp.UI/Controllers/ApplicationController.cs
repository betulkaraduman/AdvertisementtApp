using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Dto;
using AspNetCore.AdvertisementApp.UI.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.AdvertisementApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }
        public async Task<IActionResult> List()
        {
            var response = await _advertisementService.GetAllAsync();
            return this.ResponseView(response);
        }
        public IActionResult AddNewAdvertisement()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAdvertisement(AdvertisementCreateDto dto)
        {
            var response = await _advertisementService.CreateAsync(dto);

            return this.ResponseRedirectToAction(response, "List");
        }

        public async Task<IActionResult> updateAdvertisement(int AdvertisementId)
        {
            var response = await _advertisementService.GetByIdAsync<AdvertisementUpdateDto>(AdvertisementId);
            return this.ResponseView(response);

        }

        [HttpPost]
        public async Task<IActionResult> updateAdvertisement(AdvertisementUpdateDto dto)
        {
            var oldAdvertisement =await _advertisementService.GetByIdAsync<AdvertisementUpdateDto>(dto.Id);
            var response = await _advertisementService.UpdateAsync(dto);
            return this.ResponseRedirectToAction(response,"List");
        
        }

        public async Task<IActionResult> deleteAdvertisement(int AdvertisementId)
        {
            var response =await _advertisementService.RemoveAsycn(AdvertisementId);
            return this.ResponseRedirectToAction(response, "List");
        }
    }
}
