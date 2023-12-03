using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegan.api.DTO.builder
{
    public class RestauranteDTOBuilder
    {
        private RestauranteDTO _restauranteDto = new RestauranteDTO();
        public RestauranteDTOBuilder WithIdRes(int idres)
        {
            _restauranteDto.IdRes = idres;
            return this;
        }
        public RestauranteDTOBuilder WithIdFornecedor(int idfornecedor)
        {
            _restauranteDto.IdFornecedor = idfornecedor;
            return this;
        }
        public RestauranteDTOBuilder WithNomeRes(string nomeres)
        {
            _restauranteDto.NomeRes = nomeres;
            return this;
        }
        public RestauranteDTOBuilder WithDescricaoRes(string descricaores)
        {
            _restauranteDto.DescriaoRes = descricaores;
            return this;
        }

        public RestauranteDTO Build()
        {
            return _restauranteDto;
        }
    }
}
