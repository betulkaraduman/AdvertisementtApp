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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(i => i.RoleName).HasMaxLength(300).IsRequired();
            builder.HasData(new AppRole[]
            {
                new AppRole(){RoleName="Admin",Id=1},
                new AppRole(){RoleName="Member",Id=2}
            });
        }
    }
}
