using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IaraAPI.Models
{
    public class DadosRetorno
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
    }
}
