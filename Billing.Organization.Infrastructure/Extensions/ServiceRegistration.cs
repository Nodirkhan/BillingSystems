using Billing.Organization.Infrastructure.Context;
using Billing.Organization.Infrastructure.Intefaces;
using Billing.Organization.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Organization.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddTransient<IServiceRepositoryAsync, ServiceRepositoryAsync>();
            services.AddTransient<IOrganizationRepositoryAsync, OrganizationRepositoryAsync>();
            services.AddTransient<IInstitutionRepositoryAsync, InstitutionRepositoryAsync>();
        }
    }
}
