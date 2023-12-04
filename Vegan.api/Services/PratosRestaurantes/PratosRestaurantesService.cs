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

namespace Vegan.api.Services.PratosRestaurantes
{
    public class PratosRestaurantesService : IPratosRestaurantesService
    {
        private readonly IPratosRestaurantesRepository _pratosrestaurantesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PratosRestaurantesService(IPratosRestaurantesRepository pratosrestaurantesRepository, IUnitOfWork unitOfWork)
        {
            _pratosrestaurantesRepository = pratosrestaurantesRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PratoRestaurante>> GetAllPratosAsync()
        {
            return await _pratosrestaurantesRepository.GetAllPratosAsync();
        }
        public async Task<PratoRestaurante> GetPratoByIdAsync(int id)
        {
            PratoRestaurante pratorestaurante = await _pratosrestaurantesRepository.GetPratoByIdAsync(id);

            if (pratorestaurante is null)
            {
                throw new NotFoundException("Prato");
            }

            return pratorestaurante;
        }
        public async Task<PratoRestaurante> CreatePratoAsync(PratoRestaurante pratorestaurante)
        {
            PratoRestaurante pratorestauranteExists = await _pratosrestaurantesRepository.FindByNomePratoAsync(pratorestaurante.NomePrato);

            if (pratorestauranteExists != null && !pratorestauranteExists.Equals(pratorestaurante))
            {
                throw new BadRequestException("Prato já existe");
            }

            await _pratosrestaurantesRepository.AddPratoAsync(pratorestaurante);
            await _unitOfWork.SaveChangesAsync();
            return pratorestaurante;
        }

        public async Task DeletePratoAsync(int id)
        {
            PratoRestaurante pratorestauranteExists = await _pratosrestaurantesRepository.GetPratoByIdAsync(id);

            if (pratorestauranteExists is null)
            {
                throw new NotFoundException("Prato");
            }

            await _pratosrestaurantesRepository?.DeletePrato(pratorestauranteExists);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdatePratoAsync(int id, PratoRestaurante pratorestaurante)
        {
            PratoRestaurante pratorestauranteExists = await GetPratoByIdAsync(id);
            if (pratorestauranteExists is null)
            {
                throw new NotFoundException("Prato");
            }
            pratorestauranteExists.NomePrato = pratorestaurante.NomePrato;
            pratorestauranteExists.DescricaoPrato = pratorestaurante.DescricaoPrato;
            pratorestauranteExists.PrecoPrato = pratorestaurante.PrecoPrato;
            await _pratosrestaurantesRepository.UpdatePratoAsync(pratorestaurante);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
