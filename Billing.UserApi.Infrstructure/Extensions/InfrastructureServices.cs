using Billing.UserApi.Infrstructure.Data;
using Billing.UserApi.Infrstructure.Interface;
using Billing.UserApi.Infrstructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.UserApi.Infrstructure.Extensions
{
    public static class InfrastructureServices
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
        }
    }
}
