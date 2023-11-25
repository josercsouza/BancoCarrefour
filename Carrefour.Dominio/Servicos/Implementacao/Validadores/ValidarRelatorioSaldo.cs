using System;

namespace Carrefour.Dominio.Servicos.Implementacao.Validadores
{
    public static class ValidarRelatorioSaldo
    {
        public static bool Validar(string dataInicial, string dataFinal)
        {
            DateTime dtInicial, dtFinal;

            if (!DateTime.TryParse(dataInicial, out dtInicial))
            {
                dtInicial = DateTime.Now;
            }

            if (!DateTime.TryParse(dataFinal, out dtFinal))
            {
                dtFinal = DateTime.Now;
            }
            dtFinal = dtFinal.AddDays(1);

            return dtFinal > dtInicial;
        }
    }
}
