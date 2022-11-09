using System.Collections.Generic;

namespace Billing.Organization.Domains.Models
{
    public class InstitutionDTO
    {
        public string Name { get; set; }

        public long AccountNumber { get; set; }

        public OrganizationForGetDTO Organization { get; set; }

    }
}
