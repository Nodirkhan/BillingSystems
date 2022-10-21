using System;

namespace Billing.UserApi.Domains.Models
{
    public class UserForGetDTO : UserDTO
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public string CreatedByUserId { get; set; }

        public string LastModifiedById { get; set; }
    }
}
