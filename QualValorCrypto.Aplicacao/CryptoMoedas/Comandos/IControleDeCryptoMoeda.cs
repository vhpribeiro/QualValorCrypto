using System.Threading.Tasks;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Comandos
{
    public interface IControleDeCryptoMoeda
    {
        public Task InserirCryptoMoedaAsync(CryptoMoeda item);
        public Task AtualizarCryptoMoeda(decimal novoValor, string nomeDaMoeda);
    }
}