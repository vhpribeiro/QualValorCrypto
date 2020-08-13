using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QualValorCrypto.Dominio
{
    public class Entity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}