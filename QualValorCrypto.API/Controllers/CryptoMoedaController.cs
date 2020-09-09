using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.Consultas;
using QualValorCrypto.Dominio;
using QualValorCrypto.Infra.UnitOfWorks;

namespace QualValorCrypto.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CryptoMoedaController : Controller
    {
        private readonly IConsultaDeCryptoMoeda _consultaDeCryptoMoeda;
        private readonly IControleDeCryptoMoeda _controleDeCryptoMoeda;
        private readonly IUnitOfWork _unitOfWork;

        public CryptoMoedaController(IConsultaDeCryptoMoeda consultaDeCryptoMoeda, IControleDeCryptoMoeda controleDeCryptoMoeda, IUnitOfWork unitOfWork)
        {
            _consultaDeCryptoMoeda = consultaDeCryptoMoeda;
            _controleDeCryptoMoeda = controleDeCryptoMoeda;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterCryptoMoeda(string id)
        {
            return Ok(_consultaDeCryptoMoeda.ObterCryptoMoedaPeloIdentificador(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> InserirCryptoMoeda([FromBody] CryptoMoeda cryptoMoeda)
        {
            try
            {
                await _controleDeCryptoMoeda.InserirCryptoMoedaAsync(cryptoMoeda);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch
            {
                return Problem();
            }
            
        }
    }
}