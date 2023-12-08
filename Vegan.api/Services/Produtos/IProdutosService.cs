using Vegan.api.Models;

namespace Vegan.api.Services.Produtos
{
    public interface IProdutosService
    {
        public Task<IEnumerable<Produto>> GetAllProdutosAsync();
        public Task<Produto> GetProdutoByIdAsync(int id);
        Task<Produto> GetProdutoByNomeProdAsync(string nomeProduto);
        public Task<Produto> AddProdutoAsync(Produto produto);
        public Task DeleteProdutoAsync(int id);
        public Task UpdateProdutoAsync(int id, Produto produto);
        
    }
}
