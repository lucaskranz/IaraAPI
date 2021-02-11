using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IaraAPI.Models
{
    public class Cotacao
    {
        [Key]
        public int CotacaoId { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "O Campo Descrição suporta apenas {1} caracteres")]
        public string CNPJComprador { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "O Campo Descrição suporta apenas {1} caracteres")]
        public string CNPJFornecedor { get; set; }

        [Required]
        public int NumeroCotacao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCotacao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEntregaCotacao { get; set; }
    }
}
