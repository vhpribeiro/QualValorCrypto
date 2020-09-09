using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using QualValorCrypto.Dominio;
using QualValorCrypto.Infra.UnitOfWorks;

namespace QualValorCrypto.Infra
{   
    public abstract class MongoDbBase<T> where T : Entity
    {
        private readonly IMongoDbContext _mongoDbContext;
        private IMongoDatabase DataBase { get; }
        private MongoClient Mongo { get; }
        protected IMongoCollection<T> Collection { get; }
    
        protected MongoDbBase(IMongoDbContext mongoDbContext, IConfiguration configuration, string nomeDaColecao)
        {
            _mongoDbContext = mongoDbContext;
            Mongo = new MongoClient(configuration.GetValue<string>("Database:Url"));
            DataBase = Mongo.GetDatabase(configuration.GetValue<string>("Database:Name"));
            Collection = DataBase.GetCollection<T>(nomeDaColecao);
        }

        public virtual T ObterPeloIdentificador(string id) => Collection.Find(x => x.Id == id).FirstOrDefault();

        public virtual Task InserirItemAsync(T item)
        {
            return _mongoDbContext.AddCommand(async () => await Collection.InsertOneAsync(item));
        } 
    }
}