using System.Collections.Generic;

namespace Billing.Authentication.Domains.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
