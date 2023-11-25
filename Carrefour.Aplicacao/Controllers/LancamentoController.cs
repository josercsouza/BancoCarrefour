using Carrefour.Dominio.Interfaces;
using Carrefour.Dominio.ObjetosDeValor;
using Carrefour.Dominio.Servicos.Implementacao.Validadores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carrefour.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly IServicoDeLancamento _servicoDeLancamento;

        public LancamentoController(IServicoDeLancamento servicoDeLancamento) => _servicoDeLancamento = servicoDeLancamento;

        /// <summary>
        /// Lancamento do movimento diario
        /// </summary>
        /// <param name="lancamentoOV">Data e valor de lancamento (Positivo = credito / Negativo = debito)</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LancamentoOV lancamentoOV)
        {
            if (!ValidarLancamento.Validar(lancamentoOV))
                return BadRequest(new { sucesso = false });

            await _servicoDeLancamento.Adicionar(lancamentoOV);

            return Ok(new { sucesso = true });
        }
    }
}
