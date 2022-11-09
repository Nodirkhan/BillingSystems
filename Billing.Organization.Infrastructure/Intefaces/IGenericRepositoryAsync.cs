using Billing.Organization.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.Organization.Infrastructure.Intefaces
{
    public interface IGenericRepositoryAsync<TEntity> : IDisposable where TEntity: BaseEntity 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetOneAsync(Guid id);
        Task<IEnumerable<TEntity>> GetPageListAsync(int pageNumber, int pageSize);
        Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter, List<string> tables);
        Task CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<bool> SaveChangesAsync();
    }
}
