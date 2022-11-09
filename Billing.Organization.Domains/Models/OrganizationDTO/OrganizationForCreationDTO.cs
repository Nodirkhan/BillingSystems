using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Billing.Organization.Domains.Models
{
    public class OrganizationForCreationDTO : OrganizationDTO
    {
        [JsonIgnore]
        public override Guid Id { get; set; }

        [JsonIgnore]
        public override IEnumerable<ServiceDTO> ChildOrganizations { get; set; }
    }
}
