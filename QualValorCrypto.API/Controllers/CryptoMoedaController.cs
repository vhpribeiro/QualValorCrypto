using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using QualValorCrypto.Aplicacao.CryptoMoedas.Consultas;

namespace QualValorCrypto.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CryptoMoedaController : Controller
    {
        private readonly IConsultaDeCryptoMoeda _consultaDeCryptoMoeda;

        public CryptoMoedaController(IConsultaDeCryptoMoeda consultaDeCryptoMoeda)
        {
            _consultaDeCryptoMoeda = consultaDeCryptoMoeda;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterCryptoMoeda(string id)
        {
            return Ok(_consultaDeCryptoMoeda.ObterCryptoMoedaAsync(new ObjectId(id)));
        }
    }
}