using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Infra
{   
    public abstract class MongoDbBase<T> where T : Entity
    {
        private IMongoDatabase DataBase { get; }
        private MongoClient Mongo { get; }
        private IMongoCollection<T> Collection { get; }
    
        protected MongoDbBase(IConfiguration configuration, string nomeDaColecao)
        {
            Mongo = new MongoClient(configuration.GetSection("Database:Url").ToString());
            DataBase = Mongo.GetDatabase(configuration.GetSection("Database:Name").ToString());
            Collection = DataBase.GetCollection<T>(nomeDaColecao);
        }
    
        protected virtual T ObterPeloIdentificador(ObjectId id) => Collection.Find(x => x.Id == id).FirstOrDefault();
    }
}