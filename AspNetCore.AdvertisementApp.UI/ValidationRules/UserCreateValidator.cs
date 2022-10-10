using AspNetCore.AdvertisementApp.UI.Models;
using FluentValidation;

namespace AspNetCore.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateValidator()
        {

            //CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(i => i.Username).NotEmpty();
            RuleFor(i => i.Password).NotEmpty();
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.Password).MinimumLength(3);

            RuleFor(i => i.ConfirmPassword).Equal(x => x.Password).WithMessage("Password not match");
            RuleFor(i => new
            {
                i.FirstName,
                i.Username
            }).Must(x => CanNotFirstName(x.Username, x.FirstName)).WithMessage("Username can not include firstname").When(x => x.Username != null && x.FirstName != null);
            RuleFor(i => i.GenderId).NotEmpty();
        }

        private bool CanNotFirstName(string username, string firstName)
        {
            return !username.Contains(firstName);
        }
    }
}
