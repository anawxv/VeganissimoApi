using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;

namespace Vegan.api.DTO
{
    public class PratoRestauranteDTO
    {
        public int IdPrato {  get; set; }
        public int IdRes { get; set; }
        public string NomePrato { get; set; }
        public string DescricaoPrato { get; set; }
        public int PrecoPrato { get; set; }
       
    }
}
