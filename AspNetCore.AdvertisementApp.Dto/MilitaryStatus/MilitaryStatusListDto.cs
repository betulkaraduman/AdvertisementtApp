using AspNetCore.AdvertisementApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Dto
{
    public class MilitaryStatusListDto:IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
