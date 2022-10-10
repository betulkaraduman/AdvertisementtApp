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
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(i => i.Title).HasMaxLength(300).IsRequired();
            builder.Property(i => i.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(i => i.Description).HasColumnType("ntext").IsRequired();
            builder.Property(i => i.CreatedDate).HasDefaultValueSql("getdate()");

        }
    }
}
