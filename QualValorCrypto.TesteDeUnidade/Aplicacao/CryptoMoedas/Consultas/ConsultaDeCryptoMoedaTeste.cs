using Bogus;
using ExpectedObjects;
using Moq;
using QualValorCrypto.Aplicacao.CryptoMoedas.Consultas;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Dominio;
using Xunit;

namespace QualValorCrypto.TesteDeUnidade.Aplicacao.CryptoMoedas.Consultas
{
    public class ConsultaDeCryptoMoedaTeste
    {
        private readonly Faker _faker;
        private readonly Mock<ICryptoMoedaRepositorio> _cryptoMoedaRepositorio;
        private readonly ConsultaDeCryptoMoeda _consultaDeCryptoMoeda;

        public ConsultaDeCryptoMoedaTeste()
        {
            _faker = new Faker();
            _cryptoMoedaRepositorio = new Mock<ICryptoMoedaRepositorio>();
            _consultaDeCryptoMoeda = new ConsultaDeCryptoMoeda(_cryptoMoedaRepositorio.Object);
        }
        
        [Fact]
        public void Deve_obter_crypto_moeda_pelo_identificador()
        {
            var id = _faker.Random.String2(8);
            var valorDaCryptoMoeda = _faker.Random.Decimal();
            var nomeDaCryptoMoeda = _faker.Random.String2(8);
            var cryptoMoedaEsperada = new CryptoMoeda(id, nomeDaCryptoMoeda, valorDaCryptoMoeda);
            _cryptoMoedaRepositorio.Setup(cmr => cmr.ObterPeloIdentificador(id)).Returns(cryptoMoedaEsperada);
            
            var cryptoMoedaObtida = _consultaDeCryptoMoeda.ObterCryptoMoedaPeloIdentificador(id);
            
            cryptoMoedaEsperada.ToExpectedObject().ShouldMatch(cryptoMoedaObtida);
        }
    }
}