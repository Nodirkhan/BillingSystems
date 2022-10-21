using Billing.UserApi.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.UserApi.Infrstructure.Interface
{
    public interface IUserRepositoryAsync
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<(IEnumerable<User> users, long totalCount)> GetPageListAsync(int pageNumber, int pageSize);
        Task<User> FindbyCondition(Expression<Func<User, bool>> expression);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        Task<bool> IsExist(string userName);
    }
}
