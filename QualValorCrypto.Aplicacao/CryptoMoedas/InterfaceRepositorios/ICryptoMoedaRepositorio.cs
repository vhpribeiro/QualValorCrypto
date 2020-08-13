using MongoDB.Bson;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios
{
    public interface ICryptoMoedaRepositorio
    {
        public CryptoMoeda ObterCryptoMoedaAsync(ObjectId id);
    }
}