using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;

namespace Vegan.api.DTO
{
    public class ProdutoDTO
    {
        public int IdProd { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeProd { get; set; }
        public string DescricaoProd { get; set; }
        public int PrecoProd { get; set; }
        
    }
}
