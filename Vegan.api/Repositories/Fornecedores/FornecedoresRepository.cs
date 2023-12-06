using Vegan.api.Data;
using Vegan.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vegan.api.Repositories.Fornecedores
{
    public class FornecedoresRepository : IFornecedoresRepository
    {
        private readonly DataContext _dataContext;
        public FornecedoresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync()
        {
            return await _dataContext.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> GetFornecedorByIdAsync(int id)
        {
            return await _dataContext.Fornecedores.FirstOrDefaultAsync(f => f.IdFornecedor == id);
        }

        public async Task AddFornecedorAsync(Fornecedor fornecedor)
        {
            await _dataContext.Fornecedores.AddAsync(fornecedor);
        }

        public async Task DeleteFornecedor(Fornecedor fornecedor)
        {
            _dataContext.Fornecedores.Remove(fornecedor);
        }

        public async Task UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            _dataContext.Update(fornecedor);
        }

        public async Task<Fornecedor> FindUserByEmailAsync(string email)
        {
            return await _dataContext.Fornecedores.FirstOrDefaultAsync(c => c.Email == email);
        }
    }

}
