using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carrefour.Dominio.Entidades
{
    [Table("Lancamento")]
    public class Lancamento
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("AnoMes")]
        [Required, MaxLength(7)]
        public string AnoMes { get; set; }

        [Column("DataEfetiva")]
        [Required]
        public DateTime DataEfetiva { get; set; }

        [Column("Valor")]
        [Required]
        public decimal Valor { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }
    }
}
