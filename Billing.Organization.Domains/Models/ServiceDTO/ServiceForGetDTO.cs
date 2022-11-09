using System;

namespace Billing.Organization.Domains.Models
{
    public class ServiceForGetDTO : ServiceDTO
    {
        public Guid Id { get; set; }
        public InstitutionForGetDTO Institution { get; set; }

    }
}
