using AspNetCore.AdvertisementApp.DataAccess.Configurations;
using AspNetCore.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.DataAccess.Contexts
{
    public class AdvertisementDbContext:DbContext
    {
        public AdvertisementDbContext(DbContextOptions<AdvertisementDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementUser> AdvertisementUsers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AdvertisementUserStatus> AdvertisementUserStatuses { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
        public DbSet<UserGender> UserGenders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserGenderConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }
    }
}
