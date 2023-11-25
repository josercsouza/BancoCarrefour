using Carrefour.Dominio.Entidades;
using Carrefour.Infraestrutura.Config;
using Microsoft.EntityFrameworkCore;
using System;

namespace Carrefour.Infraestrutura.Dados
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ContextConfig.CarrefourDB,
                    options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 4,
                            maxRetryDelay: TimeSpan.FromSeconds(1),
                            errorNumbersToAdd: Array.Empty<int>());
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<ContaCorrente>(cc =>
            {
                cc.HasMany(c => c.Lancamentos).WithOne(l => l.ContaCorrente).HasForeignKey(q => q.AnoMes).IsRequired();
            });
        }

        public virtual DbSet<ContaCorrente> ContaCorrente { get; set; }

        public virtual DbSet<Lancamento> Lancamento { get; set; }
    }
}
