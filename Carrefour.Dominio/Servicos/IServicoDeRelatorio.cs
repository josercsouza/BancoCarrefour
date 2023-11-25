using Carrefour.Dominio.ObjetosDeValor;
using System.Threading.Tasks;

namespace Carrefour.Dominio.Interfaces
{
    public interface IServicoDeRelatorio
    {
        Task<RelatorioSaldoOV> ObterSaldo(string dataInicial, string dataFinal, bool sintetico);
    }
}
