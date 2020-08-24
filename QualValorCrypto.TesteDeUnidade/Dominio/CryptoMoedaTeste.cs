using Bogus;
using ExpectedObjects;
using QualValorCrypto.Dominio;
using Xunit;

namespace QualValorCrypto.TesteDeUnidade.Dominio
{
    public class CryptoMoedaTeste
    {
        private readonly Faker _faker;

        public CryptoMoedaTeste()
        {
            _faker = new Faker();
        }
        
        [Fact]
        public void Deve_criar_uma_crypto_moeda()
        {
            var id = _faker.Random.Int(0).ToString();
            var nome = _faker.Random.String2(8);
            var valor = _faker.Random.Decimal();
            var cryptoMoedaEsperada = new
            {
                Id = id,
                Nome = nome,
                Valor = valor
            };
            
            var cryptoMoedaObtida = new CryptoMoeda(id, nome, valor);
            
            cryptoMoedaEsperada.ToExpectedObject().ShouldMatch(cryptoMoedaObtida);
        }
    }
}