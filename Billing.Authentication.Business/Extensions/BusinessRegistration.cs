using Billing.Authentication.Business.Interface;
using Billing.Authentication.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Authentication.Business.Extensions
{
    public static class BusinessRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IUserServiceAsync, UserServiceAsync>();
            
        }
    }
}
