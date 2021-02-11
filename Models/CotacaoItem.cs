using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IaraAPI.Models
{
    public class CotacaoItem
    {
        [Key]
        public int CotacaoItemId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O Campo Descrição suporta apenas {1} caracteres")]
        public string Descricao { get; set; }

        [Required]
        public int NumeroItem { get; set; }

        public double Preco { get; set; }

        [Required]
        public double Quantidade { get; set; }

        [MaxLength(50, ErrorMessage = "O Campo Descrição suporta apenas {1} caracteres")]
        public string Marca { get; set; }

        [MaxLength(5, ErrorMessage = "O Campo Descrição suporta apenas {1} caracteres")]
        public string Unidade { get; set; }
    }
}
