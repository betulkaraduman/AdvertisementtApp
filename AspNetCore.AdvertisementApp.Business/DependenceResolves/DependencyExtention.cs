using AspNetCore.AdvertisementApp.Business.Interfaces;
using AspNetCore.AdvertisementApp.Business.Mappings;
using AspNetCore.AdvertisementApp.Business.Services;
using AspNetCore.AdvertisementApp.Business.ValidationRules;
using AspNetCore.AdvertisementApp.DataAccess.Contexts;
using AspNetCore.AdvertisementApp.DataAccess.UnifOfWork;
using AspNetCore.AdvertisementApp.Dto;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Business.DependenceResolves
{
    public static class DependencyExtention
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddDbContext<AdvertisementDbContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-NSE9T2O\\SQLEXPRESS01;database=AdvertisementDb_011022;integrated security=true");
                //opt.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);
            });



            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServicesCreateDto>, ProvidedServicesCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServicesUpdateDto>, ProvidedServicesUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserRoleCreateDto>, AppUserRoleCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserRoleUpdateDto>, AppUserRoleUpdateDtoValidator>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAppUserRoleService, AppUserRoleService>();
        }

    }
}
