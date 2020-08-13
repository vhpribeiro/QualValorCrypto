using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Infra.Repositorios
{
    public class CryptoMoedaRepositorio : MongoDbBase<CryptoMoeda>, ICryptoMoedaRepositorio
    {
        private static string NomeDaColecao => "Crypto";
        
        public CryptoMoedaRepositorio(IConfiguration configuration) : base(configuration, NomeDaColecao)
        {
        }
        
        public CryptoMoeda ObterCryptoMoedaAsync(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}