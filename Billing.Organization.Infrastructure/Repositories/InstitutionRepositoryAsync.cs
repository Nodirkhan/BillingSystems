using Billing.Organization.Domains.Entities;
using Billing.Organization.Infrastructure.Context;
using Billing.Organization.Infrastructure.Intefaces;

namespace Billing.Organization.Infrastructure.Repositories
{
    public class InstitutionRepositoryAsync : GenericRepositoryAsync<Institution>, IInstitutionRepositoryAsync
    {
        public InstitutionRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }
    }
}
