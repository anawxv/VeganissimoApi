using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Models;
using Vegan.api.Repositories.Unit_of_Work;
using Vegan.api.Exceptions;
using Vegan.api.Repositories;
using Vegan.api.Repositories.Fornecedores;
using Vegan.api.Repositories.PratosRestaurantes;
using Vegan.api.Repositories.Restaurantes;
using Vegan.api.Repositories.Produtos;

namespace Vegan.api.Services.Produtos
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutosService(IProdutosRepository produtosRepository, IUnitOfWork unitOfWork)
        {
            _produtosRepository = produtosRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _produtosRepository.GetAllProdutosAsync();
        }
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            Produto produto = await _produtosRepository.GetProdutoByIdAsync(id);

            if (produto is null)
            {
                throw new NotFoundException("Produto");
            }

            return produto;
        }


        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            Produto produtoExists = await _produtosRepository.GetProdutoByIdAsync(produto.IdProd);
            if (produto != null)
            {
                throw new Exception("Produto já existe.");
            }

            if (string.IsNullOrEmpty(produto.NomeProd))
            {
                throw new Exception("O produto precisa de um nome.");
            }
            await _produtosRepository.AddProdutoAsync(produto);
            await _unitOfWork.SaveChangesAsync();
            return produto;

        }
        public async Task DeleteProdutoAsync(int id)
        {
            Produto produtoExists = await _produtosRepository.GetProdutoByIdAsync(id);

            if (produtoExists is null)
            {
                throw new NotFoundException("Produto");
            }

            await _produtosRepository?.DeleteProduto(produtoExists);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {
            Produto produtoExists = await GetProdutoByIdAsync(id);
            if (produtoExists is null)
            {
                throw new NotFoundException("Produto");
            }
            produtoExists.NomeProd = produto.NomeProd;
            produtoExists.DescricaoProd = produto.DescricaoProd;
            produtoExists.PrecoProd = produto.PrecoProd;
            await _produtosRepository.UpdateProdutoAsync(produto);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}



