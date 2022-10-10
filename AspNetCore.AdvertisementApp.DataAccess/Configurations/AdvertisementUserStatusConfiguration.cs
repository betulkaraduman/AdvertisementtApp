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
    public class AdvertisementUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementUserStatus> builder)
        {
            builder.Property(i => i.Definition).HasMaxLength(150);
        }
    }
}
