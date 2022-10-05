using MongoDB.Bson.Serialization.Attributes;

namespace Billing.Authentication.Domains.Entities
{
    [BsonIgnoreExtraElements]
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
