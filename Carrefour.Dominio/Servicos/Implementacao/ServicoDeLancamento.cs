using Carrefour.Dominio.Entidades;
using Carrefour.Dominio.Interfaces;
using Carrefour.Dominio.ObjetosDeValor;
using Carrefour.Dominio.Repositorios;
using System;
using System.Threading.Tasks;

namespace Carrefour.Dominio.Servicos.Implementacao
{
    public class ServicoDeLancamento : IServicoDeLancamento
    {
        private readonly IRepositorioDeContaCorrente _repositorioDeContaCorrente;

        public ServicoDeLancamento(IRepositorioDeContaCorrente repositorioDeContaCorrente)
        {
            _repositorioDeContaCorrente = repositorioDeContaCorrente;
        }

        public async Task Adicionar(LancamentoOV lancamentoOV)
        {
            var anoMes = lancamentoOV.DataEfetiva.ToString("u")[..7];

            var lancamento = new Lancamento
            {
                AnoMes = anoMes,
                DataEfetiva = lancamentoOV.DataEfetiva,
                Valor = lancamentoOV.Valor,
            };

            var contaCorrente = await _repositorioDeContaCorrente.ObterSaldoDoAnoMes(anoMes);

            if (contaCorrente == null)
            {
                contaCorrente = new ContaCorrente() { AnoMes = anoMes, SaldoDaConta = lancamento.Valor };
                contaCorrente.Lancamentos.Add(lancamento);

                _repositorioDeContaCorrente.Adicionar(contaCorrente);
            }
            else
            {
                contaCorrente.SaldoDaConta += lancamento.Valor;
                contaCorrente.Lancamentos.Add(lancamento);

                _repositorioDeContaCorrente.Atualizar(contaCorrente);
            }

            // Atualizacao dos saldos futuros a partir da data de lancamento

            DateTime primeiroDiaDoMesLancamento = new DateTime(int.Parse(anoMes[..4]), int.Parse(anoMes[5..]), 1, 0, 0, 0);
            DateTime primeiroDiaDesteMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

            while (DateTime.Compare(primeiroDiaDoMesLancamento, primeiroDiaDesteMes) < 0)
            {
                primeiroDiaDoMesLancamento = primeiroDiaDoMesLancamento.AddMonths(1);
                anoMes = primeiroDiaDoMesLancamento.ToString("u")[..7];

                contaCorrente = await _repositorioDeContaCorrente.ObterSaldoDoAnoMes(anoMes);

                if (contaCorrente != null)
                {
                    contaCorrente.SaldoDaConta += lancamento.Valor;

                    _repositorioDeContaCorrente.Atualizar(contaCorrente);
                }
            }
        }
    }
}
