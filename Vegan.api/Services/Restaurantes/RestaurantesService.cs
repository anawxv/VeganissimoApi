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

namespace Vegan.api.Services.Restaurantes
{
    public class RestaurantesService : IRestaurantesService
    {
        private readonly IRestaurantesRepository _restaurantesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantesService(IRestaurantesRepository restaurantesRepository, IUnitOfWork unitOfWork)
        {
            _restaurantesRepository = restaurantesRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Restaurante>> GetAllRestaurantesAsync()
        {
            return await _restaurantesRepository.GetAllRestaurantesAsync();
        }
        public async Task<Restaurante> GetRestauranteByIdAsync(int id)
        {
            Restaurante restaurante = await _restaurantesRepository.GetRestauranteByIdAsync(id);

            if (restaurante is null)
            {
                throw new NotFoundException("Restaurante");
            }

            return restaurante;
        }
        public async Task<Restaurante> GetRestauranteByNomeResAsync(string nome)
        {
            Restaurante restaurante = await _restaurantesRepository.GetRestauranteByNomeResAsync(nome);

            if (restaurante is null)
            {
                throw new NotFoundException("Produto");
            }

            return restaurante;
        }

        public async Task<Restaurante> AddRestauranteAsync(Restaurante restaurante)
        {
            Restaurante restauranteExists = await _restaurantesRepository.GetRestauranteByNomeResAsync(restaurante.NomeRes);
            if (restaurante != null)
            {
                throw new Exception("O restaurante já existe.");
            }

            if (string.IsNullOrEmpty(restaurante.NomeRes))
            {
                throw new Exception("O restaurante precisa de um nome.");
            }
            await _restaurantesRepository.AddRestauranteAsync(restaurante);
            await _unitOfWork.SaveChangesAsync();
            return restaurante;
        }

        public async Task DeleteRestauranteAsync(int id)
        {
            Restaurante restauranteExists = await _restaurantesRepository.GetRestauranteByIdAsync(id);

            if (restauranteExists is null)
            {
                throw new NotFoundException("Restaurante");
            }

            await _restaurantesRepository?.DeleteRestaurante(restauranteExists);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateRestauranteAsync(int id, Restaurante restaurante)
        {
            Restaurante restauranteExists = await GetRestauranteByIdAsync(id);
            if (restauranteExists is null)
            {
                throw new NotFoundException("Restaurante");
            }
            restauranteExists.NomeRes = restaurante.NomeRes;
            restauranteExists.DescricaoRes = restaurante.DescricaoRes;
            restauranteExists.PratosRestaurantes = restaurante.PratosRestaurantes;
            await _restaurantesRepository.UpdateRestauranteAsync(restaurante);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
