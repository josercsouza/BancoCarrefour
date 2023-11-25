using Carrefour.Dominio.ObjetosDeValor;
using System;

namespace Carrefour.Dominio.Servicos.Implementacao.Validadores
{
    public static class ValidarLancamento
    {
        public static bool Validar(LancamentoOV lancamentoOV)
        {
            return lancamentoOV.Valor != 0 && lancamentoOV.DataEfetiva != DateTime.MinValue && DateTime.Now >= lancamentoOV.DataEfetiva;
        }
    }
}
