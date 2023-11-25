using Carrefour.Dominio.Interfaces;
using Carrefour.Dominio.ObjetosDeValor;
using Carrefour.Dominio.Servicos.Implementacao.Validadores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carrefour.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IServicoDeRelatorio _servicoDeRelatorio;

        public RelatorioController(IServicoDeRelatorio servicoDeRelatorio) => _servicoDeRelatorio = servicoDeRelatorio;

        /// <summary>
        /// Retorna o saldo da conta do periodo consolidado diariamente
        /// </summary>
        /// <param name="dataInicial">Data inicial do periodo (Ex: 2022-11-10). Se vazio, será considerado a data de hoje</param>
        /// <param name="dataFinal">Data inicial do periodo (Ex: 2022-11-10). Se vazio, será considerado a data de hoje</param>
        /// <param name="sintetico">Se verdadeiro (true), não traz os lancamentos do dia</param>
        /// <returns></returns>
        [HttpGet("saldo")]
        public async Task<ActionResult<RelatorioSaldoOV>> Get(string dataInicial, string dataFinal, bool sintetico = true)
        {
            if (!ValidarRelatorioSaldo.Validar(dataInicial, dataFinal))
                return BadRequest(new RelatorioSaldoOV());

            return Ok(await _servicoDeRelatorio.ObterSaldo(dataInicial, dataFinal, sintetico));
        }
    }
}
