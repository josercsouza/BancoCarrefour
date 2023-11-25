using Carrefour.Dominio.Entidades;
using Carrefour.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrefour.Infraestrutura.Dados.Repositorios
{
    public class RepositorioDeContaCorrente : IRepositorioDeContaCorrente
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeContaCorrente() => _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();

        #region ContaCorrente

        public async Task<ContaCorrente> ObterSaldoDoAnoMes(string anoMes)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<ContaCorrente>().FirstOrDefaultAsync(x => x.AnoMes == anoMes);
        }

        public async void Adicionar(ContaCorrente contaCorrente)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<ContaCorrente>().Add(contaCorrente);
            await contexto.SaveChangesAsync();
        }

        public async void Atualizar(ContaCorrente contaCorrente)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<ContaCorrente>().Update(contaCorrente);
            await contexto.SaveChangesAsync();
        }

        #endregion ContaCorrente

        #region Lancamento

        public async Task<Lancamento> ExisteLancamentoMenor(DateTime data)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<Lancamento>()
                .Include(l => l.ContaCorrente)
                .OrderByDescending(o => o.DataEfetiva)
                .FirstOrDefaultAsync(x => x.DataEfetiva < data);
        }

        public async Task<List<Lancamento>> ObterLancamentos(DateTime dtInicial, DateTime dtFinal)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<Lancamento>()
                .AsNoTracking()
                .OrderBy(o => o.DataEfetiva)
                .Where(x => x.DataEfetiva >= dtInicial && x.DataEfetiva < dtFinal)
                .ToListAsync();
        }

        #endregion Lancamento
    }
}
