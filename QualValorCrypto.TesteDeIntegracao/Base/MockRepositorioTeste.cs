using System.Threading.Tasks;
using Mongo2Go;
using MongoDB.Driver;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.TesteDeIntegracao.Base
{
    public class MockRepositorioTeste : ICryptoMoedaRepositorio
    {
        internal static MongoDbRunner _runner;
        internal static IMongoCollection<CryptoMoeda> _collection;

        internal static void CreateConnection()
        {
            _runner = MongoDbRunner.Start();
        
            var client = new MongoClient(_runner.ConnectionString);
            var database = client.GetDatabase("IntegrationTest");
            _collection = database.GetCollection<CryptoMoeda>("TestCollection");
        }

        public CryptoMoeda ObterPeloIdentificador(string id) => _collection.Find(x => x.Id == id).FirstOrDefault();

        public async Task InserirItemAsync(CryptoMoeda item) => await _collection.InsertOneAsync(item);
        public Task AtualizarValorPeloNomeAsync(decimal novoValor, string nomeDaMoeda)
        {
            throw new System.NotImplementedException();
        }
    }
}