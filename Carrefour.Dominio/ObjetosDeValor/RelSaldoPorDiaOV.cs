using System.Collections.Generic;

namespace Carrefour.Dominio.ObjetosDeValor
{
    public class RelSaldoPorDiaOV
    {
        public string Data { get; set; }
        public decimal SaldoAnterior { get; set; } = 0;
        public decimal Credito { get; set; } = 0;
        public decimal Debito { get; set; } = 0;

        public List<RelLancamentoOV> Valores { get; set; } = new List<RelLancamentoOV>();

        public decimal SaldoAtual
        {
            get
            {
                return SaldoAnterior + Credito - Debito;
            }
        }
    }
}
