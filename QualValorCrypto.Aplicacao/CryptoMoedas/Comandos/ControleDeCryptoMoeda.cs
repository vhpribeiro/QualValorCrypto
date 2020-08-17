using System.Threading.Tasks;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Comandos
{
    public class ControleDeCryptoMoeda : IControleDeCryptoMoeda
    {
        private readonly ICryptoMoedaRepositorio _cryptoMoedaRepositorio;

        public ControleDeCryptoMoeda(ICryptoMoedaRepositorio cryptoMoedaRepositorio)
        {
            _cryptoMoedaRepositorio = cryptoMoedaRepositorio;
        }

        public async Task InserirCryptoMoedaAsync(CryptoMoeda cryptoMoeda) => await _cryptoMoedaRepositorio.InserirItemAsync(cryptoMoeda);

        public async Task AtualizarCryptoMoeda(decimal novoValor, string nomeDaMoeda) =>
            await _cryptoMoedaRepositorio.UpdateAsync(novoValor, nomeDaMoeda);
    }
}