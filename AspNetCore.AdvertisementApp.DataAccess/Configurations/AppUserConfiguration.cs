using AspNetCore.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(i => i.FirstName).HasMaxLength(300).IsRequired();
            builder.Property(i => i.LastName).HasMaxLength(300).IsRequired();
            builder.Property(i => i.Username).HasMaxLength(300).IsRequired();
            builder.Property(i => i.PhoneNumber).HasMaxLength(300).IsRequired();
            builder.Property(i => i.Password).HasMaxLength(300).IsRequired();
            builder.HasOne(i => i.UserGender).WithMany(i => i.AppUsers).HasForeignKey(i => i.GenderId);
        }
    }
}
