using Microsoft.AspNetCore.Mvc;
using Vegan.api.DTO;
using Vegan.api.Exceptions;
using Vegan.api.Models;
using Vegan.api.Services;
using Vegan.api.http;
using Vegan.api.Services.Fornecedores;
using static Vegan.api.http.HttpResponse;


namespace Vegan.api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedoresService _fornecedoresService;

        public FornecedorController(IFornecedoresService fornecedoresService)
        {
            _fornecedoresService = fornecedoresService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Fornecedor> fornecedores = await _fornecedoresService.GetAllFornecedoresAsync();
                IEnumerable<FornecedorDTO> fornecedoresDTO = fornecedores.Select(e => e.ToFornecedor());
                return Ok(fornecedoresDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<FornecedorDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Fornecedor fornecedor = await _fornecedoresService.GetFornecedorByIdAsync(id);
                FornecedorDTO fornecedorDto = fornecedor.ToFornecedor();
                return HttpResponseApi<FornecedorDTO>.Ok(fornecedorDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HttpResponseApi<FornecedorDTO>))]
        public async Task<IActionResult> CreateFornecedorAsync([FromBody] Fornecedor fornecedor)
        {
            try
            {
                Fornecedor forncedorExists = await _fornecedoresService.CreateFornecedorAsync(fornecedor);
                FornecedorDTO fornecedorDto = forncedorExists.ToFornecedor();
                return HttpResponseApi<FornecedorDTO>.Created(fornecedorDto);
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
        public async Task<IActionResult> DeleteFornecedorAsync(int id)
        {
            try
            {
                await _fornecedoresService.DeleteFornecedorAsync(id);
                return NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFornecedorAsync(int id, [FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _fornecedoresService.UpdateFornecedorAsync(id, fornecedor);
                return NoContent();
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }
    }
}

