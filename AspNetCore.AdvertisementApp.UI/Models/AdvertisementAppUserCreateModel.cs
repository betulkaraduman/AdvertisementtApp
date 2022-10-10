using AspNetCore.AdvertisementApp.Common.Enums;

namespace AspNetCore.AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Appied;
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvPath { get; set; }
    }
}
