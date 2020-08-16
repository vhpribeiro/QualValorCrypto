using System.Threading.Tasks;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Comandos
{
    public class CricaoDeCryptoMoeda : ICriacaoDeCryptoMoeda
    {
        private readonly ICryptoMoedaRepositorio _cryptoMoedaRepositorio;

        public CricaoDeCryptoMoeda(ICryptoMoedaRepositorio cryptoMoedaRepositorio)
        {
            _cryptoMoedaRepositorio = cryptoMoedaRepositorio;
        }

        public async Task InserirItemAsync(CryptoMoeda cryptoMoeda) => await _cryptoMoedaRepositorio.InserirItemAsync(cryptoMoeda);
    }
}