using Billing.Organization.Domains.Enums;
using System;
using System.Collections.Generic;

namespace Billing.Organization.Domains.Models
{
    public class OrganizationDTO
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual RegionType RegionType { get; set; }

        public virtual long AccountNumber { get; set; }

        public virtual Guid ParentId { get; set; } = Guid.Empty;

        public virtual IEnumerable<ServiceDTO> ChildOrganizations { get; set; }

    }
}
