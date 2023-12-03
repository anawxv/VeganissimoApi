using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegan.api.DTO.builder
{
    public class ProdutoDTOBuilder
    {

        private ProdutoDTO _produtoDto = new ProdutoDTO();
        public ProdutoDTOBuilder WithIdProd(int idprod)
        {
            _produtoDto.IdProd = idprod;
            return this;
        }

        public ProdutoDTOBuilder WithIdFornecedor(int idfornecedor)
        {
            _produtoDto.IdFornecedor = idfornecedor;
            return this;
        }

        public ProdutoDTOBuilder WithNomeProd(string nomeprod)
        {
            _produtoDto.NomeProd = nomeprod;
            return this;
        }

        public ProdutoDTOBuilder WithDescricaoProd(string descricaoprod)
        {
            _produtoDto.DescricaoProd = descricaoprod;
            return this;
        }

        public ProdutoDTOBuilder WithPrecoProd(int precoprod)
        {
            _produtoDto.PrecoProd = precoprod;
            return this;
        }

        public ProdutoDTO Build()
        {
            return _produtoDto;
        }
    }
}
