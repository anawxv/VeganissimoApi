using Microsoft.AspNetCore.Mvc;
using Vegan.api.DTO;
using Vegan.api.Exceptions;
using Vegan.api.Models;
using Vegan.api.Services;
using Vegan.api.http;
using Vegan.api.Services.Fornecedores;
using static Vegan.api.http.HttpResponse;
using Vegan.api.Services.PratosRestaurantes;
using Vegan.api.Services.Produtos;

namespace Vegan.api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutoController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Produto> produtos = await _produtosService.GetAllProdutosAsync();
                IEnumerable<ProdutoDTO> produtosDTO = produtos.Select(e => e.ToProduto());
                return Ok(produtosDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<ProdutoDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetProdutoByIdAsync(int id)
        {
            try
            {
                Produto produto = await _produtosService.GetProdutoByIdAsync(id);
                ProdutoDTO produtoDto = produto.ToProduto();
                return HttpResponseApi<ProdutoDTO>.Ok(produtoDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        /*[HttpGet("{nomeProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<ProdutoDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetProdutoByNomeProdAsync(string nomeProduto)
        {
            try
            {
                Produto produto = await _produtosService.GetProdutoByNomeProdAsync(nomeProduto);

                if (produto is null)
                {
                    throw new NotFoundException("Produto");
                }

                ProdutoDTO produtoDto = produto.ToProduto();
                return HttpResponseApi<ProdutoDTO>.Ok(produtoDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        } */



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HttpResponseApi<ProdutoDTO>))]
        public async Task<IActionResult> CreatePratoAsync([FromBody] Produto produto)
        {
            try
            {
                Produto produtoExists = await _produtosService.AddProdutoAsync(produto);
                ProdutoDTO produtoDto = produtoExists.ToProduto();
                return HttpResponseApi<ProdutoDTO>.Created(produtoDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        /* [HttpPost]
        public async Task<IActionResult> Create(Fornecedor novoFornecedor)
        {
            try
            {
                //await _fornecedorService.CreateFornecedorAsync(novoFornecedor);

                Fornecedor fornecedor = await _fornecedoresService.CreateFornecedorAsync(novoFornecedor);
                FornecedorDTO fornecedorDTO = fornecedor.ToFornecedor();

                return HttpResponseApi<FornecedorDTO>.Created(fornecedorDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        } */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoAsync(int id)
        {
            try
            {
                await _produtosService.DeleteProdutoAsync(id);
                return NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProdutoAsync(int id, [FromBody] Produto produto)
        {
            try
            {
                await _produtosService.UpdateProdutoAsync(id, produto);
                return NoContent();
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }
    }
}
 