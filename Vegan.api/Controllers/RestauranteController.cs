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
using Vegan.api.Services.Restaurantes;
using Microsoft.EntityFrameworkCore;

namespace Vegan.api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestaurantesService _restaurantesService;

        public RestauranteController(IRestaurantesService restaurantesService)
        {
            _restaurantesService = restaurantesService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Restaurante> restaurantes = await _restaurantesService.GetAllRestaurantesAsync();
                IEnumerable<RestauranteDTO> restaurantesDTO = restaurantes.Select(e => e.ToRestaurante());
                return Ok(restaurantesDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<RestauranteDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetRestauranteByIdAsync(int id)
        {
            try
            {
                Restaurante restaurante = await _restaurantesService.GetRestauranteByIdAsync(id);
                RestauranteDTO restauranteDto = restaurante.ToRestaurante();
                return HttpResponseApi<RestauranteDTO>.Ok(restauranteDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        /*[HttpGet("{nomeRestaurante}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HttpResponseApi<RestauranteDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpErrorResponse))]
        public async Task<IActionResult> GetRestauranteByNomeResAsync(string nomeRestaurante)
        {
            try
            {
                Restaurante restaurante = await _restaurantesService.GetRestauranteByNomeResAsync(nomeRestaurante);

                if (restaurante is null)
                {
                    throw new NotFoundException("Restaurante");
                }

                RestauranteDTO restauranteDto = restaurante.ToRestaurante();
                return HttpResponseApi<RestauranteDTO>.Ok(restauranteDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        } */



         [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HttpResponseApi<RestauranteDTO>))]
        public async Task<IActionResult> CreateRestauranteAsync([FromBody] Restaurante restaurante)
        {
            try
            {
                Restaurante restauranteExists = await _restaurantesService.AddRestauranteAsync(restaurante);
                RestauranteDTO restauranteDto = restauranteExists.ToRestaurante();
                return HttpResponseApi<RestauranteDTO>.Created(restauranteDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        } 

        /* [HttpPost]
        public async Task<IActionResult> Create(Restaurante novoRestaurante)
        {
            try
            {
                

                Restaurante restaurante = await _restaurantesService.AddRestauranteAsync(novoRestaurante);
                RestauranteDTO retauranteDTO = restaurante.ToRestaurante();

                return HttpResponseApi<RestauranteDTO>.Create(retauranteDTO);
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
        } */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestauranteAsync(int id)
        {
            try
            {
                await _restaurantesService.DeleteRestauranteAsync(id);
                return NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestauranteAsync(int id, [FromBody] Restaurante restaurante)
        {
            try
            {
                await _restaurantesService.UpdateRestauranteAsync(id, restaurante);
                return NoContent();
            }
            catch (BaseException ex)
            {

                return ex.GetResponse();
            }
   

        }
    }

}
