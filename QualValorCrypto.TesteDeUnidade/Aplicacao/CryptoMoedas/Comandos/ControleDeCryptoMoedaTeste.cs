using System.Threading.Tasks;
using Bogus;
using Moq;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;
using Xunit;

namespace QualValorCrypto.TesteDeUnidade.Aplicacao.CryptoMoedas.Comandos
{
    public class ControleDeCryptoMoedaTeste
    {
        private readonly Faker _faker;
        private readonly Mock<ICryptoMoedaRepositorio> _cryptoMoedaRepositorio;
        private readonly ControleDeCryptoMoeda _controleDeCryptoMoeda;

        public ControleDeCryptoMoedaTeste()
        {
            _faker = new Faker();
            _cryptoMoedaRepositorio = new Mock<ICryptoMoedaRepositorio>();
            _controleDeCryptoMoeda = new ControleDeCryptoMoeda(_cryptoMoedaRepositorio.Object);
        }
        
        [Fact]
        public async Task Deve_inserir_uma_crypto_moeda_async()
        {
            var id = _faker.Random.String2(8);
            var nomeDaCryptoMoeda = _faker.Random.String2(8);
            var valorDaCryptoMoeda = _faker.Random.Decimal();
            var cryptoMoeda = new CryptoMoeda(id, nomeDaCryptoMoeda, valorDaCryptoMoeda);
            _cryptoMoedaRepositorio.Setup(cmr => cmr.InserirItemAsync(It.IsAny<CryptoMoeda>()));
            
            await _controleDeCryptoMoeda.InserirCryptoMoedaAsync(cryptoMoeda);
            
            _cryptoMoedaRepositorio.Verify(cmr => cmr.InserirItemAsync(cryptoMoeda));
        }

        [Fact]
        public async Task Deve_atualizar_o_valor_da_crypto_moeda_pelo_seu_nome_async()
        {
            var nomeDaCryptoMoeda = _faker.Random.String2(8);
            var novoValor = _faker.Random.Decimal();
            _cryptoMoedaRepositorio.Setup(cmr => cmr
                .AtualizarValorPeloNomeAsync(It.IsAny<decimal>(), It.IsAny<string>()));
            
            await _controleDeCryptoMoeda.AtualizarValorPeloNomeAsync(novoValor, nomeDaCryptoMoeda);
            
            _cryptoMoedaRepositorio.Verify(cmr => cmr.AtualizarValorPeloNomeAsync(novoValor, nomeDaCryptoMoeda));
        }
    }
}