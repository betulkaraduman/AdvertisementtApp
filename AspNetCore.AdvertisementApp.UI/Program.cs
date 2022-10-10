using AspNetCore.AdvertisementApp.Business.DependenceResolves;
using AspNetCore.AdvertisementApp.Business.Helpers;
using AspNetCore.AdvertisementApp.UI.Mappings;
using AspNetCore.AdvertisementApp.UI.Models;
using AspNetCore.AdvertisementApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDependency();
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateValidator>();

var profiles = ProfileHelper.GetProfiles();
profiles.Add(new UserCreateModelProfile());
profiles.Add(new AdvertisementAppUserCreateModelProfile());

var configure = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = configure.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "AdvertisementCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan=TimeSpan.FromDays(20);
        opt.LoginPath =new  PathString("/Account/Login");
        opt.LogoutPath = new PathString("/Account/Logout");
        opt.AccessDeniedPath = new PathString("/Account/AccessDenied");

    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
