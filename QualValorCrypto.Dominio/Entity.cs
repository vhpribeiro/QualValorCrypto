using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QualValorCrypto.Dominio
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}