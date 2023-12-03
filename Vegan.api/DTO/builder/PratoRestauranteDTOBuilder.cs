using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Vegan.api.DTO.builder
{
    public class PratoRestauranteDTOBuilder
    {
        private PratoRestauranteDTO _pratorestauranteDto = new PratoRestauranteDTO();

        public PratoRestauranteDTOBuilder WithIdPrato(int idprato)
        {
            _pratorestauranteDto.IdPrato = idprato;
            return this;
        }

        public PratoRestauranteDTOBuilder WithIdRes(int idres)
        {
            _pratorestauranteDto.IdRes = idres;
            return this;
        }
        public PratoRestauranteDTOBuilder WithNomePrato(string nomeprato)
        {
            _pratorestauranteDto.NomePrato = nomeprato;
            return this;
        }
        public PratoRestauranteDTOBuilder WithDescricaoPrato(string descricaoprato)
        {
            _pratorestauranteDto.DescricaoPrato = descricaoprato;
            return this;
        }
        public PratoRestauranteDTOBuilder WithPrecoPrato(int precoprato)
        {
            _pratorestauranteDto.PrecoPrato = precoprato;
            return this;
        }
        public PratoRestauranteDTO Build()
        {
            return _pratorestauranteDto;
        }
    }
}
