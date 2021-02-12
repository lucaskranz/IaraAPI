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
        [MaxLength(14, ErrorMessage = "O Campo CNPJComprador suporta apenas {1} caracteres")]
        public string CNPJComprador { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "O Campo CNPJFornecedor suporta apenas {1} caracteres")]
        public string CNPJFornecedor { get; set; }

        [Required]
        public int NumeroCotacao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCotacao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEntregaCotacao { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "O Campo CEP suporta apenas {1} caracteres")]
        public string CEP { get; set; }

        [MaxLength(50, ErrorMessage = "O Campo Logradouro suporta apenas {1} caracteres")]
        public string Logradouro { get; set; }

        [MaxLength(50, ErrorMessage = "O Campo Complemento suporta apenas {1} caracteres")]
        public string Complemento { get; set; }

        [MaxLength(30, ErrorMessage = "O Campo Bairro suporta apenas {1} caracteres")]
        public string Bairro { get; set; }

        [MaxLength(2, ErrorMessage = "O Campo UF suporta apenas {1} caracteres")]
        public string UF { get; set; }

        [MaxLength(200, ErrorMessage = "O Campo Observação suporta apenas {1} caracteres")]
        public string Observação { get; set; }

        public List<CotacaoItem> CotacaoItens { get; set; }
    }
}
