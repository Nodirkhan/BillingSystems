using Billing.Organization.Domains.Entities;
using Billing.Organization.Infrastructure.Context;
using Billing.Organization.Infrastructure.Intefaces;

namespace Billing.Organization.Infrastructure.Repositories
{
    public class ServiceRepositoryAsync : GenericRepositoryAsync<Service>, IServiceRepositoryAsync
    {
        public ServiceRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }
    }
}
