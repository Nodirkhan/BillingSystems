using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.Authentication.Infrastructure.Interface
{
    public interface IBaseRepositoryAsync<TEntity>  where TEntity : class 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetOneAsync(string id);
        Task<IEnumerable<TEntity>> GetPageListAsync(int pageNumber, int pageSize);
        Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(string id, TEntity entity);
        void DeleteAsync(string id);
    }
}
