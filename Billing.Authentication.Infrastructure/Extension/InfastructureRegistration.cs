using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Infrastructure.Data;
using Billing.Authentication.Infrastructure.Interface;
using Billing.Authentication.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Authentication.Infrastructure.Extension
{
    public static class InfastructureRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            var connectionSetting = config.GetSection("ConnectionSetting");
            services.Configure<ConnectionSetting>(c => connectionSetting.Bind(c));
        }
    }
}
