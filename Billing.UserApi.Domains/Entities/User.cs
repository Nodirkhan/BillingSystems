using Billing.UserApi.Domains.Statics;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Billing.UserApi.Domains.Entities
{
    public class User : BaseAudible
    {
        [BsonElement]
        public string FirstName { get; set; }

        [BsonElement]
        public string LastName { get; set; }

        [BsonElement]
        public string UserName { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        public string Email { get; set; }

        [BsonElement]
        public string PhoneNumber { get; set; }

        [BsonElement]
        public int Position { get; set; }

        [BsonElement]
        public List<string> Permission { get; set; } = new();

        [BsonElement]
        public string Role { get; set; }

        public virtual void SetPermission() =>
            PermissionCreater.GetPermission(Position, Permission);

        public virtual void SetRole() =>
            Role = RoleCreater.GetRole(Position);
        public virtual void SetCreatedDateTime() => 
            this.CreatedDate = DateTime.Now;

        public virtual void SetModifiedDate() =>
            this.LastModifiedDate = DateTime.Now;

    }
}
