using System;
using System.Collections.Generic;

namespace Billing.Organization.Domains.Entities
{
    public class Institution : Base
    {
        public Institution()
        {
            Services = new List<Service>();
        }
        public string Name { get; set; }
       
        public long AccountNumber { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        
        public ICollection<Service> Services { get; set; }

    }

}
