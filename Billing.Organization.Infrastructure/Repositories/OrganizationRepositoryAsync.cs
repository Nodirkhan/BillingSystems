using Billing.Organization.Domains.Entities;
using Billing.Organization.Infrastructure.Context;
using Billing.Organization.Infrastructure.Intefaces;

namespace Billing.Organization.Infrastructure.Repositories
{
    internal class OrganizationRepositoryAsync : GenericRepositoryAsync<Domains.Entities.Organization>, IOrganizationRepositoryAsync
    {
        public OrganizationRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }
    }
}
