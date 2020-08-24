using MongoDB.Bson;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Consultas
{
    public interface IConsultaDeCryptoMoeda
    {
        public CryptoMoeda ObterCryptoMoedaPeloIdentificador(string id);
    }
}