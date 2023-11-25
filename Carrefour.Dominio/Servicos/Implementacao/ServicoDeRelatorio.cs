using Carrefour.Dominio.Interfaces;
using Carrefour.Dominio.ObjetosDeValor;
using Carrefour.Dominio.Repositorios;
using System;
using System.Threading.Tasks;

namespace Carrefour.Dominio.Servicos.Implementacao
{
    public class ServicoDeRelatorio : IServicoDeRelatorio
    {
        private readonly IRepositorioDeContaCorrente _repositorioDeContaCorrente;

        public ServicoDeRelatorio(IRepositorioDeContaCorrente repositorioDeContaCorrente)
        {
            _repositorioDeContaCorrente = repositorioDeContaCorrente;
        }

        public async Task<RelatorioSaldoOV> ObterSaldo(string dataInicial, string dataFinal, bool sintetico)
        {
            RelatorioSaldoOV relatorioSaldo = new();

            DateTime dtInicial, dtFinal;

            if (!DateTime.TryParse(dataInicial, out dtInicial))
            {
                dtInicial = DateTime.Now;
            }
            dtInicial = dtInicial.Date;

            if (!DateTime.TryParse(dataFinal, out dtFinal))
            {
                dtFinal = DateTime.Now.Date;
            }
            dtFinal = dtFinal.AddDays(1).Date;

            var anoMes = dtInicial.ToString("u")[..7];

            DateTime inicioMes = new DateTime(int.Parse(anoMes[..4]), int.Parse(anoMes[5..]), 1, 0, 0, 0);

            var lancamento = await _repositorioDeContaCorrente.ExisteLancamentoMenor(inicioMes);

            decimal saldoAnterior = lancamento?.ContaCorrente.SaldoDaConta ?? 0;

            var lancamentos = await _repositorioDeContaCorrente.ObterLancamentos(inicioMes, dtFinal);

            RelSaldoPorDiaOV relSaldoOV = new();
            int index = 0;

            while (index < lancamentos.Count)
            {
                var dtLancamento = lancamentos[index].DataEfetiva.Date;

                if (dtLancamento >= dtInicial)
                {
                    relSaldoOV = new RelSaldoPorDiaOV() { Data = dtLancamento.ToString("u")[..10], SaldoAnterior = saldoAnterior };
                }

                while (index < lancamentos.Count && lancamentos[index].DataEfetiva.Date == dtLancamento)
                {
                    decimal valor = lancamentos[index].Valor;

                    if (dtLancamento >= dtInicial)
                    {
                        if (valor < 0)
                        {
                            relSaldoOV.Debito -= valor;
                        }
                        else
                        {
                            relSaldoOV.Credito += valor;
                        }

                        if (!sintetico)
                        {
                            relSaldoOV.Valores.Add(new RelLancamentoOV() { DataEfetiva = lancamentos[index].DataEfetiva, Valor = valor });
                        }
                    }

                    saldoAnterior += valor;
                    index++;
                }

                if (dtLancamento >= dtInicial)
                {
                    relatorioSaldo.Itens.Add(relSaldoOV);
                }
            }

            return relatorioSaldo;
        }
    }
}
