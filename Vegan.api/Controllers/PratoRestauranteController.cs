using Microsoft.AspNetCore.Mvc;
using Vegan.api.DTO;
using Vegan.api.Exceptions;
using Vegan.api.Models;
using Vegan.api.Services;
using Vegan.api.http;
using Vegan.api.Services.Fornecedores;
using static Vegan.api.http.HttpResponse;
using Vegan.api.Services.PratosRestaurantes;

namespace Vegan.api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PratoRestauranteController : ControllerBase
    {
        private readonly IPratosRestaurantesService _pratosrestaurantesService;

        public PratoRestauranteController(IPratosRestaurantesService pratosrestaurantesService)
        {
            _pratosrestaurantesService = pratosrestaurantesService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<PratoRestaurante> pratosrestaurantes = await _pratosrestaurantesService.GetAllPratosAsync();
                IEnumerable<PratoRestauranteDTO> pratosrestaurantesDTO = pratosrestaurantes.Select(e => e.ToPratoRestaurante());
                return Ok(pratosrestaurantesDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("prato/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<PratoRestauranteDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetPratoByIdAsync(int id)
        {
            try
            {
                PratoRestaurante pratorestaurante = await _pratosrestaurantesService.GetPratoByIdAsync(id);
                PratoRestauranteDTO pratorestauranteDto = pratorestaurante.ToPratoRestaurante();
                return HttpResponseApi<PratoRestauranteDTO>.Ok(pratorestauranteDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HttpResponseApi<PratoRestauranteDTO>))]
        public async Task<IActionResult> CreatePratoAsync([FromBody] PratoRestaurante pratorestaurante)
        {
            try
            {
                PratoRestaurante pratorestauranteExists = await _pratosrestaurantesService.AddPratoAsync(pratorestaurante);
                PratoRestauranteDTO pratorestauranteDto = pratorestauranteExists.ToPratoRestaurante();
                return HttpResponseApi<PratoRestauranteDTO>.Created(pratorestauranteDto);
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
        public async Task<IActionResult> DeletePratoAsync(int id)
        {
            try
            {
                await _pratosrestaurantesService.DeletePratoAsync(id);
                return NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePratoAsync(int id, [FromBody] PratoRestaurante pratorestaurante)
        {
            try
            {
                await _pratosrestaurantesService.UpdatePratoAsync(id, pratorestaurante);
                return NoContent();
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }


    }
}
