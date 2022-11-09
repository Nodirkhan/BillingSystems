using System;
using System.ComponentModel.DataAnnotations;

namespace Billing.Organization.Domains
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
