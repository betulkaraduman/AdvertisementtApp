using AspNetCore.AdvertisementApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Dto
{
    public class AdvertisementAppUserListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }

        public int AdvertisementUserStatusId { get; set; }
        public AdvertisementUserStatusListDto AdvertisementUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public int WorkExperience { get; set; }
        public DateTime? EndDate { get; set; }
        public string CvPath { get; set; }

    }
}
