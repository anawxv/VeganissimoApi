using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;
using Vegan.api.Repositories.Unit_of_Work;
using Vegan.api.Exceptions;
using Vegan.api.Repositories;
using Vegan.api.Repositories.Fornecedores;



namespace Vegan.api.Services.Fornecedores
{
    public class FornecedoresService : IFornecedoresServices
    {

        private readonly IFornecedoresRepository _fornecedoresRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FornecedoresService(IFornecedoresRepository fornecedoresRepository, IUnitOfWork unitOfWork)
        {
            _fornecedoresRepository = fornecedoresRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync()
        {
            return await _fornecedoresRepository.GetAllFornecedoresAsync();
        }
        public async Task<Fornecedor> GetFornecedorByIdAsync(int id)
        {
            Fornecedor fornecedor = await _fornecedoresRepository.GetFornecedorByIdAsync(id);

            if (fornecedor is null)
            {
                throw new NotFoundException("Fornecedor");
            }

            return fornecedor;
        }
        public async Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor)
        {
            Fornecedor fornecedorExists = await _fornecedoresRepository.FindUserByEmailAsync(fornecedor.Email);

            if (fornecedorExists != null && !fornecedorExists.Equals(fornecedor))
            {
                throw new BadRequestException("Fornecedor já existe");
            }

            await _fornecedoresRepository.AddFornecedorAsync(fornecedor);
            await _unitOfWork.SaveChangesAsync();
            return fornecedor;
        }

        public async Task DeleteFornecedorAsync(int id)
        {
            Fornecedor fornecedorExists = await _fornecedoresRepository.GetFornecedorByIdAsync(id);

            if (fornecedorExists is null)
            {
                throw new NotFoundException("Fornecedor");
            }

            await _fornecedoresRepository?.DeleteFornecedor(fornecedorExists);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateFornecedorAsync(int id, Fornecedor fornecedor)
        {
            Fornecedor fornecedorExists = await GetFornecedorByIdAsync(id);
            if (fornecedorExists is null)
            {
                throw new NotFoundException("Fornecedor");
            }
            fornecedorExists.Email = fornecedor.Email;
            fornecedorExists.Nome = fornecedor.Nome;
            fornecedorExists.Phone = fornecedor.Phone;
            await _fornecedoresRepository.UpdateFornecedorAsync(fornecedor);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
