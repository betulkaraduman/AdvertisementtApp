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
    public class AdvertisementUserConfiguration : IEntityTypeConfiguration<AdvertisementUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementUser> builder)
        {
            builder.HasIndex(i => new
            {
                i.AppUserId,
                i.AdvertisementId
            }).IsUnique();
            builder.Property(i => i.CvPath).HasMaxLength(500).IsRequired();
            builder.HasOne(i => i.AppUser).WithMany(i => i.AdvertisementUsers).HasForeignKey(i => i.AppUserId);
            builder.HasOne(i => i.Advertisement).WithMany(i => i.AdvertisementUsers).HasForeignKey(i => i.AdvertisementId);
            builder.HasOne(i => i.AdvertisementUserStatus).WithMany(i => i.AdvertisementUsers).HasForeignKey(i => i.AdvertisementUserStatusId);
            builder.HasOne(i => i.MilitaryStatus).WithMany(i => i.AdvertisementUsers).HasForeignKey(i => i.MilitaryStatusId);
        }
    }
}
