using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Entities
{
    public class AppRole:BaseEntity
    {
        public string RoleName { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
