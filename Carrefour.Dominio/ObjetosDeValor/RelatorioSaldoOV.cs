using System.Collections.Generic;

namespace Carrefour.Dominio.ObjetosDeValor
{
    public class RelatorioSaldoOV
    {
        public List<RelSaldoPorDiaOV> Itens { get; set; } = new List<RelSaldoPorDiaOV>();
    }
}
