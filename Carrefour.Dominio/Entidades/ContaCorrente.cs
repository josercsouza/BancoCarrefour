using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carrefour.Dominio.Entidades
{
    [Table("ContaCorrente")]
    public class ContaCorrente
    {
        // Levando em consideração que temos somente 1 conta para controlar

        public ContaCorrente()
        {
            Lancamentos = new HashSet<Lancamento>();
        }

        [Key]
        [Column("AnoMes")]
        [Required, MaxLength(7)]
        public string AnoMes { get; set; }

        [Column("SaldoDaConta")]
        public decimal SaldoDaConta { get; set; } = 0;

        public virtual ICollection<Lancamento> Lancamentos { get; set; }
    }
}
