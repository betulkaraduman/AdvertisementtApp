using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.Dto;
using FluentValidation;

namespace AspNetCore.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator:AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(i=>i.AppUserId).NotEmpty();
            RuleFor(i => i.AdvertisementId).NotEmpty();
            RuleFor(i => i.WorkExperience).NotEmpty();
            RuleFor(i=>i.CvPath).NotEmpty();

            RuleFor(i=>i.AdvertisementUserStatusId).NotEmpty();
            RuleFor(i => i.EndDate).NotEmpty().When(i => i.MilitaryStatusId == (int)MilitaryStatusType.Deferred);

        }
    }
}
