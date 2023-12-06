using Vegan.api.Models;


namespace Vegan.api.Repositories.Produtos
{
    public interface IProdutosRepository 
    {
        public Task<IEnumerable<Produto>> GetAllProdutosAsync();
        public Task<Produto> GetProdutoByIdAsync(int id);
        public Task AddProdutoAsync(Produto produto);
        public Task DeleteProduto(Produto produto);
        public Task UpdateProdutoAsync(Produto produto);
    }
}
