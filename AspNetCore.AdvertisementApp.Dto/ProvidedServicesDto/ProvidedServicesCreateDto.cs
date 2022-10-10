using AspNetCore.AdvertisementApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Dto
{
    public class ProvidedServicesCreateDto:IDto
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
