using System;
using System.ComponentModel.DataAnnotations;

namespace Carrefour.Dominio.ObjetosDeValor
{
    public class LancamentoOV
    {
        [Required]
        public DateTime DataEfetiva { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
