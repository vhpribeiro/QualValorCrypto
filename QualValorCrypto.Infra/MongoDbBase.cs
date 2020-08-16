using System.Threading.Tasks;
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
            Mongo = new MongoClient(configuration.GetValue<string>("Database:Url"));
            DataBase = Mongo.GetDatabase(configuration.GetValue<string>("Database:Name"));
            Collection = DataBase.GetCollection<T>(nomeDaColecao);
        }

        public virtual T ObterPeloIdentificador(string id) => Collection.Find(x => x.Id == id).FirstOrDefault();
        
        public virtual async Task InserirItemAsync(T item) => await Collection.InsertOneAsync(item);
    }
}