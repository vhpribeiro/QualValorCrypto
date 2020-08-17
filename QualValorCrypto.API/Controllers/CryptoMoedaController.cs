using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.Consultas;
using QualValorCrypto.Dominio;

namespace QualValorCrypto.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CryptoMoedaController : Controller
    {
        private readonly IConsultaDeCryptoMoeda _consultaDeCryptoMoeda;
        private readonly IControleDeCryptoMoeda _controleDeCryptoMoeda;

        public CryptoMoedaController(IConsultaDeCryptoMoeda consultaDeCryptoMoeda, IControleDeCryptoMoeda controleDeCryptoMoeda)
        {
            _consultaDeCryptoMoeda = consultaDeCryptoMoeda;
            _controleDeCryptoMoeda = controleDeCryptoMoeda;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterCryptoMoeda(string id)
        {
            return Ok(_consultaDeCryptoMoeda.ObterCryptoMoedaAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> InserirCryptoMoeda([FromBody] CryptoMoeda cryptoMoeda)
        {
            await _controleDeCryptoMoeda.InserirCryptoMoedaAsync(cryptoMoeda);
            return Ok();
        }
    }
}