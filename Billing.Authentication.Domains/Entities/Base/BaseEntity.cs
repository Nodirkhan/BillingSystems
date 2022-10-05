using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Billing.Authentication.Domains.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        
    }
}
