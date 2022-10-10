using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Entities
{
    public class AppUserRole:BaseEntity
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int RoleId { get; set; }
        public AppRole Role { get; set; }
    }
}
