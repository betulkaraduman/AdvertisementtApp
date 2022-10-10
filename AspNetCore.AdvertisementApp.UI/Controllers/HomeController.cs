using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.UI.Extentions;
using AspNetCore.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCore.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;
        public HomeController(ILogger<HomeController> logger, IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
            _providedService = providedService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           var response= await _providedService.GetAllAsync();
            return this.ResponseView(response);
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> HumanResource()
            {   
            var response =await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
                 
        }
    }
}