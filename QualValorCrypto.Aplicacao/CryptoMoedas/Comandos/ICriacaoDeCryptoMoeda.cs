using System.Threading.Tasks;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.Aplicacao.CryptoMoedas.Comandos
{
    public interface ICriacaoDeCryptoMoeda
    {
        public Task InserirItemAsync(CryptoMoeda item);
    }
}