using System.Threading.Tasks;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Comandos
{
    public interface IControleDeCryptoMoeda
    {
        public Task InserirCryptoMoedaAsync(CryptoMoeda item);
        public Task AtualizarValorPeloNomeAsync(decimal novoValor, string nomeDaMoeda);
    }
}