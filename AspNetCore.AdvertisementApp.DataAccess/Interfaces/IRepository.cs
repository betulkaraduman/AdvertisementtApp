using AspNetCore.AdvertisementApp.Common.Enums;
using AspNetCore.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, OrderByType orderByType = OrderByType.DESC);
        Task<T> GetById(int Id);
        void Update(T entity, T unchanged);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking=false);
        IQueryable<T> getQuery();
        Task Add(T entity);
        void Remove(T Entity);
    }
}
