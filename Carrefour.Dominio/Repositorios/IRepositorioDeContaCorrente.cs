using Carrefour.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carrefour.Dominio.Repositorios
{
    public interface IRepositorioDeContaCorrente
    {
        #region ContaCorrente

        Task<ContaCorrente> ObterSaldoDoAnoMes(string anoMes);

        void Adicionar(ContaCorrente contaCorrente);

        void Atualizar(ContaCorrente contaCorrente);

        #endregion ContaCorrente

        #region Lancamento

        Task<Lancamento> ExisteLancamentoMenor(DateTime data);

        Task<List<Lancamento>> ObterLancamentos(DateTime dtInicial, DateTime dtFinal);

        #endregion Lancamento
    }
}
