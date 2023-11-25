using Carrefour.Dominio.ObjetosDeValor;
using System;
using Xunit;

namespace Carrefour.TestesUnitarios.ContaCorrente.DadosDeTeste
{
    public class LancamentoOVDadosDeTeste : TheoryData<LancamentoOV>
    {
        public LancamentoOVDadosDeTeste()
        {
            // Sem data
            Add(new LancamentoOV
            {
                Valor = 1
            });

            // sem valor
            Add(new LancamentoOV
            {
                DataEfetiva = DateTime.Now,
            });

            // valor zerado
            Add(new LancamentoOV
            {
                DataEfetiva = DateTime.Now,
                Valor = 0
            });
        }
    }
}
