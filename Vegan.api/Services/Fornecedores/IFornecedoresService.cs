using Vegan.api.Models;

namespace Vegan.api.Services.Fornecedores
{
    public interface IFornecedoresService
    {
        public Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync();
        public Task<Fornecedor> GetFornecedorByIdAsync(int id);
        public Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor);
        public Task DeleteFornecedorAsync(int id);
        public Task UpdateFornecedorAsync(int id, Fornecedor fornecedor);
    }
}
