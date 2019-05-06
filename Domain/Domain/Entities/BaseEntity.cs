using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public virtual ObjectId Id { get; set; }
    }
}
