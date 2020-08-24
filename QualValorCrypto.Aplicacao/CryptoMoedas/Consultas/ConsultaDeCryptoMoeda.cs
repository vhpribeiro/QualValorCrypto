using MongoDB.Bson;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Consultas
{
    public class ConsultaDeCryptoMoeda : IConsultaDeCryptoMoeda
    {
        private readonly ICryptoMoedaRepositorio _cryptoMoedaRepositorio;

        public ConsultaDeCryptoMoeda(ICryptoMoedaRepositorio cryptoMoedaRepositorio)
        {
            _cryptoMoedaRepositorio = cryptoMoedaRepositorio;
        }

        public CryptoMoeda ObterCryptoMoedaPeloIdentificador(string id) =>
           _cryptoMoedaRepositorio.ObterPeloIdentificador(id);
    }
}