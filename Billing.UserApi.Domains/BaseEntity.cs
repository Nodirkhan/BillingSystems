using MongoDB.Bson.Serialization.Attributes;

namespace Billing.UserApi.Domains
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
