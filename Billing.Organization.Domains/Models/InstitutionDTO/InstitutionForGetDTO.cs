using System;
using System.Collections.Generic;

namespace Billing.Organization.Domains.Models
{
    public class InstitutionForGetDTO : InstitutionDTO
    {
        public Guid Id { get; set; }

        public IEnumerable<ServiceForGetDTO> Services { get; set; }

    }
}
