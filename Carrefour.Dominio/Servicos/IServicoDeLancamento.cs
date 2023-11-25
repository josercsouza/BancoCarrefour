using Carrefour.Dominio.ObjetosDeValor;
using System.Threading.Tasks;

namespace Carrefour.Dominio.Interfaces
{
    public interface IServicoDeLancamento
    {
        Task Adicionar(LancamentoOV lancamentoOV);
    }
}
