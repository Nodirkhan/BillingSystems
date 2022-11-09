using Billing.Organization.Domains.Enums;
using System;
using System.Collections.Generic;

namespace Billing.Organization.Domains.Entities
{
    public class Organization : Base
    {
        public Organization()
        {
            ChildOrganizations = new List<Organization>();
        }
        public string Name { get; set; }

        public RegionType RegionType { get; set; }
        
        public long AccountNumber { get; set; }

        public Guid ParentId { get; set; } = Guid.Empty;
        public ICollection<Organization> ChildOrganizations { get; set; }

    }
}
