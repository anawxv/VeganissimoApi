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
using Microsoft.IdentityModel.Tokens;
using Vegan.api.DTO;
using static Vegan.api.Exceptions.ProdutoAlredyExistsExceptions;

namespace Vegan.api.Services.Produtos
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFornecedoresRepository _fornecedoresRepository;
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


        /* public async Task<Produto> AddProdutoAsync(Produto produto)
         {
             Fornecedor fornecedorExists = await _fornecedoresRepository.GetFornecedorByIdAsync(produto.IdFornecedor);
             if (fornecedorExists == null)
             {
                 throw new Exception("Fornecedor não encontrado. Certifique-se de que o fornecedor existe.");
             }

             if (string.IsNullOrEmpty(produto.NomeProd))
             {
                 throw new Exception("O produto precisa de um nome.");
             }
             await _produtosRepository.AddProdutoAsync(produto);
             await _unitOfWork.SaveChangesAsync();

             return produto;

         } */

        /*  public async Task<Produto> AddProdutoAsync(Produto produto)
          {
              if (produto == null)
              {
                  throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
              }

              if (produto.IdFornecedor <= 0)
              {
                  throw new ArgumentException("IdFornecedor do produto não pode ser menor ou igual a zero.", nameof(produto.IdFornecedor));
              }


              Fornecedor fornecedorExists = await _fornecedoresRepository.GetFornecedorByIdAsync(produto.IdFornecedor);

              //if (fornecedorExists == null)
              //{
                //  throw new NotFoundException($"Fornecedor com ID {produto.IdFornecedor} não encontrado.");
             // }

              if (string.IsNullOrEmpty(produto.NomeProd))
              {
                  throw new ArgumentException("O produto precisa de um nome.", nameof(produto.NomeProd));
              }

              await _produtosRepository.AddProdutoAsync(produto);


              await _unitOfWork.SaveChangesAsync();

              return produto;
          } */

        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            Produto produtoExists = await _produtosRepository.GetProdutoByNomeProdAsync(produto.NomeProd);

            if (produtoExists != null)
            {
                throw new ProdutoAlreadyExistsException("Produto já existe", "/api/produtos", DateTimeOffset.UtcNow);
            }

            await _produtosRepository.AddProdutoAsync(produto);
            return produto;
        }



        /*
         public async Task<Produto> AddProdutoAsync(ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                throw new ArgumentNullException(nameof(produtoDTO), "Os dados do produto não podem ser nulos.");
            }

            if (produtoDTO.IdFornecedor <= 0)
            {
                throw new ArgumentException("IdFornecedor do produto não pode ser menor ou igual a zero.", nameof(produtoDTO.IdFornecedor));
            }

            // Comentando a verificação do fornecedor, para permitir adicionar produtos sem fornecedor
            // Fornecedor fornecedorExists = await _fornecedoresRepository.GetFornecedorByIdAsync(produtoDTO.IdFornecedor);

            // if (fornecedorExists == null)
            // {
            //     throw new NotFoundException($"Fornecedor com ID {produtoDTO.IdFornecedor} não encontrado.");
            // }

            if (string.IsNullOrEmpty(produtoDTO.NomeProd))
            {
                throw new ArgumentException("O produto precisa de um nome.", nameof(produtoDTO.NomeProd));
            }

            Produto produto = new Produto
            {
                IdProd = produtoDTO.IdProd,
                IdFornecedor = produtoDTO.IdFornecedor,
                NomeProd = produtoDTO.NomeProd,
                DescricaoProd = produtoDTO.DescricaoProd,
                PrecoProd = produtoDTO.PrecoProd
            };

            await _produtosRepository.AddProdutoAsync(produto);
            await _unitOfWork.SaveChangesAsync();

            return produto;
        } */


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

            await _produtosRepository.UpdateProdutoAsync(produtoExists);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Produto> GetProdutoByNomeProdAsync(string nomeProduto)
        {
            // Implement the logic to get a product by name from the repository
            // For example:
            return await _produtosRepository.GetProdutoByNomeProdAsync(nomeProduto);
        }
    }
}



