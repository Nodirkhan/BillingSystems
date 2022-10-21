using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Billing.UserApi.Domains
{
    public class BaseAudible
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public DateTime CreatedDate { get; set; }

        [BsonElement]
        public DateTime LastModifiedDate { get; set; }

        [BsonElement]
        public string CreatedByUserId { get; set; }

        [BsonElement] 
        public string LastModifiedById { get; set; }
    }
}
