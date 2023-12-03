using Vegan.api.Models;

namespace Vegan.api.Repositories.Fornecedores
{
    public interface IFornecedoresRepository
    {
        public Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync();
        public Task<Fornecedor> GetFornecedorByIdAsync(int id);
        public Task AddFornecedorAsync(Fornecedor fornecedor);
        public Task DeleteFornecedor(Fornecedor fornecedor);
        public Task UpdateFornecedorAsync(Fornecedor fornecedor);
        public Task<Fornecedor> FindUserByEmailAsync(string email);
    }
}
