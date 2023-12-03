using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegan.api.DTO.builder
{
    public class FornecedorDTOBuilder
    {
        private FornecedorDTO _fornecedorDto = new FornecedorDTO();

        public FornecedorDTOBuilder WithIdFornecedor(int idfornecedor)
        {
            _fornecedorDto.IdFornecedor = idfornecedor;
            return this;
        }
        
        
        public FornecedorDTOBuilder WithNome(string nome)
        {
            _fornecedorDto.Nome = nome;
            return this;
        }


        public FornecedorDTOBuilder WithNrdocumento(int nrdocumento)
        {
            _fornecedorDto.Nrdocumento = nrdocumento;
            return this;
        }

        public FornecedorDTOBuilder WithEmail(string email)
        {
            _fornecedorDto.Email = email;
            return this;
        }

        public FornecedorDTOBuilder WithPhone(string phone)
        {
            _fornecedorDto.Phone = phone;
            return this;
        }

        public FornecedorDTO Build()
        {
            return _fornecedorDto;
        }

    }
}