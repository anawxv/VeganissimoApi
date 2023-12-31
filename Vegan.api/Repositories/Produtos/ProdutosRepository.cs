﻿using Vegan.api.Data;
using Vegan.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vegan.api.Repositories.Produtos
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly DataContext _dataContext;
        public ProdutosRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _dataContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _dataContext.Produtos.FirstOrDefaultAsync(d => d.IdProd == id);
        }
        public async Task<Produto> GetProdutoByNomeProdAsync(string nomeProduto)
        {
            return await _dataContext.Produtos.FirstOrDefaultAsync(p => p.NomeProd == nomeProduto);
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            await _dataContext.Produtos.AddAsync(produto);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteProduto(Produto produto)
        {
            _dataContext.Produtos.Remove(produto);
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _dataContext.Update(produto);
        }
    }
    

}
