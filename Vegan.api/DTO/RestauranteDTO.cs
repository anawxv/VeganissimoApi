using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;


namespace Vegan.api.DTO
{
    public class RestauranteDTO
    {
        public int IdRes { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeRes { get; set; }
        public string DescriaoRes { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public List<PratoRestaurante> Restaurantes { get; set; } = new List<PratoRestaurante>();
    }
}
