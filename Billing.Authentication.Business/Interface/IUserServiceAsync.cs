using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Domains.Models;
using System.Threading.Tasks;

namespace Billing.Authentication.Business.Interface
{
    public interface IUserServiceAsync
    {
        Task<HttpResponse> LoginAsync(Login login);
        Task<HttpResponse> CreateAsync(User user); 
    }
}
