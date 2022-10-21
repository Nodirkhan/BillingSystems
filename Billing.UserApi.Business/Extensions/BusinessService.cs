using Billing.UserApi.Business.Helpers;
using Billing.UserApi.Business.Interface;
using Billing.UserApi.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.UserApi.Business.Extensions
{
    public static class BusinessService
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IUserServiceAsync,UserServiceAsync>();
            
            services.AddAutoMapper(typeof(MappingInitializer));
        }
    }
}
