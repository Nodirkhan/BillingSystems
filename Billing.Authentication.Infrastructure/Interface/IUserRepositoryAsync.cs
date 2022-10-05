using Billing.Authentication.Domains.Entities;
using System.Threading.Tasks;

namespace Billing.Authentication.Infrastructure.Interface
{
    public interface IUserRepositoryAsync : IBaseRepositoryAsync<User>
    {
        Task<User> LoginAsync(string username, string password);
    }
}
