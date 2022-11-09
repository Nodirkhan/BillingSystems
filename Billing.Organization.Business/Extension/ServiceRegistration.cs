using Billing.Organization.Business.Helper;
using Billing.Organization.Business.Interface;
using Billing.Organization.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Organization.Business.Extension
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));

            services.AddScoped<IInstitutionServiceAsync, InstittutionServiceAsync>();
            services.AddScoped<IOrganizationServiceAsync, OrganizationServiceAsync>();
            services.AddScoped<IServiceServiceAsync, ServiceServiceAsync>();

        }
    }
}
