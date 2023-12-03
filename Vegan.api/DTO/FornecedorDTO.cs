using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;

namespace Vegan.api.DTO
{
    public record FornecedorDTO
    {

        public int IdFornecedor { get; set; }
        public int IdProd { get; set; }
        public int IdRes { get; set; }  
        public string Nome {get; set; }
        public int Nrdocumento {get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public List<RestauranteDTO> Restaurantes { get; set; } = new List<RestauranteDTO>();
    }
}