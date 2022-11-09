using System;

namespace Billing.Organization.Domains.Entities
{
    public class Service : Base
    {
        public string Name { get; set; }

        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
