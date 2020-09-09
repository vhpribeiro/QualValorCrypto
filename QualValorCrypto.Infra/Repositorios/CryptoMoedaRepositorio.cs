using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;
using QualValorCrypto.Infra.UnitOfWorks;

namespace QualValorCrypto.Infra.Repositorios
{
    public class CryptoMoedaRepositorio : MongoDbBase<CryptoMoeda>, ICryptoMoedaRepositorio
    {
        private static string NomeDaColecao => "Crypto";
        
        public CryptoMoedaRepositorio(IConfiguration configuration, IMongoDbContext mongoDbContext) : base(mongoDbContext, configuration, NomeDaColecao)
        {
        }

        public async Task AtualizarValorPeloNomeAsync(decimal novoValor, string nomeDaMoeda)
        {
            var cryptoMoedaAtualziada = Builders<CryptoMoeda>.Update.Set("Valor", novoValor);
            await Collection.UpdateOneAsync(x => x.Nome == nomeDaMoeda, cryptoMoedaAtualziada);
        }
    }
}