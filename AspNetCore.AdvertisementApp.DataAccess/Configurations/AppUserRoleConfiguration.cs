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
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(i => new
            {
                i.RoleId,
                i.UserId
            });
            builder.HasOne(i => i.User).WithMany(i => i.AppUserRoles).HasForeignKey(i => i.UserId);
            builder.HasOne(i => i.Role).WithMany(i => i.AppUserRoles).HasForeignKey(i => i.RoleId);
        }
    }
}
