using AspNetCore.AdvertisementApp.DataAccess.Contexts;
using AspNetCore.AdvertisementApp.DataAccess.Interfaces;
using AspNetCore.AdvertisementApp.DataAccess.Repositories;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.DataAccess.UnifOfWork
{
    public class Uow:IUow
    {
        //dependence injection burada gerçekleşiyor
        private readonly AdvertisementDbContext _dbContext;
        public Uow(AdvertisementDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();    
        }
    }
}
