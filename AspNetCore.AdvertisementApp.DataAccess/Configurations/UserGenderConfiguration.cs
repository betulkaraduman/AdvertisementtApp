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
    public class UserGenderConfiguration : IEntityTypeConfiguration<UserGender>
    {
        public void Configure(EntityTypeBuilder<UserGender> builder)
        {
            builder.Property(i => i.Definition).HasMaxLength(200).IsRequired();
        }
    }
}
