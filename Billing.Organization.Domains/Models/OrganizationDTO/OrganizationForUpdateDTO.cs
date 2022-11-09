using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Billing.Organization.Domains.Models
{
    public class OrganizationForUpdateDTO : OrganizationDTO
    {
        [JsonIgnore]
        public override IEnumerable<ServiceDTO> ChildOrganizations { get; set; }
    }
}
