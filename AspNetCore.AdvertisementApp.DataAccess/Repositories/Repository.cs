using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.DataAccess.Contexts;
using AspNetCore.AdvertisementApp.DataAccess.Interfaces;
using AspNetCore.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementDbContext _dbContext;
        public Repository(AdvertisementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _dbContext.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _dbContext.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _dbContext.Set<T>().AsNoTracking().OrderBy(filter).ToListAsync() : await _dbContext.Set<T>().AsNoTracking().OrderBy(filter).ToListAsync();
        }


        public async Task<T> GetById(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }
        public void Update(T entity,T unchanged)
        {
            _dbContext.Entry(unchanged).CurrentValues.SetValues(entity);
        }


        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking)
        {
            return asNoTracking ? await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :await _dbContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> getQuery()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Remove(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity); 
        }

    }
}
