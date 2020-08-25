using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using MongoDB.Driver;
using Newtonsoft.Json;
using QualValorCrypto.API;
using QualValorCrypto.Dominio;
using QualValorCrypto.TesteDeIntegracao.Base;
using Xunit;

namespace QualValorCrypto.TesteDeIntegracao
{
    public class CryptoMoedaControllerTeste : MockRepositorioTeste, IClassFixture<SetupParaTesteDeIntegracao<Startup>> 
    {
        private readonly HttpClient _cliente;
        private readonly string _urlBaseDoEndpoint;

        public CryptoMoedaControllerTeste(SetupParaTesteDeIntegracao<Startup> setupParaTesteDeIntegracao)
        { 
            _cliente = setupParaTesteDeIntegracao.WebApplicationFactory.CreateClient();
            _urlBaseDoEndpoint = "http://localhost:5000/api/cryptomoeda/";
            CreateConnection();
        }

        [Fact]
        public async Task Deve_conseguir_obter_a_crypto_moeda_informando_o_id()
        {
            const string idDaCryptoMoeda = "546c776b3e23f5f2ebdd3b03";
            var valorDoRipple = new decimal(895413.47);
            var cryptoMoedaEsperada = new CryptoMoeda(idDaCryptoMoeda, "Ripple", valorDoRipple);
            await _collection.InsertOneAsync(cryptoMoedaEsperada);
            var url = _urlBaseDoEndpoint + idDaCryptoMoeda;

            var resposta = await _cliente.GetAsync(url);

            var resultadoObtidoEmString = await resposta.Content.ReadAsStringAsync();
            var cryptoMoedaObtida = JsonConvert.DeserializeObject<CryptoMoeda>(resultadoObtidoEmString);
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            cryptoMoedaEsperada.ToExpectedObject().ShouldMatch(cryptoMoedaObtida);
            _runner.Dispose();
        }

        [Fact]
        public async Task Deve_inserir_nova_crypto_moeda()
        {
            const string idDaCryptoMoeda = "546c776b3e23f5f2ebdd3b04";
            var valorDoEtherium = new decimal(895413.47);
            var etherium = new CryptoMoeda(idDaCryptoMoeda, "Etherium", valorDoEtherium);
            var httpContent = new StringContent(JsonConvert.SerializeObject(etherium), Encoding.UTF8, "application/json");

            var resposta = await _cliente.PostAsync(_urlBaseDoEndpoint, httpContent);
            
            var cryptoMoedaQueFoiSalva = _collection.Find(x => x.Id == idDaCryptoMoeda).FirstOrDefault();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.NotNull(cryptoMoedaQueFoiSalva);
            _runner.Dispose();
        }
    }
}