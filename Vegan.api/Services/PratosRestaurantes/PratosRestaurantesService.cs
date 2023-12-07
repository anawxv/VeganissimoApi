using Vegan.api.Models;
using Vegan.api.Repositories.Unit_of_Work;
using Vegan.api.Exceptions;
using Vegan.api.Repositories.PratosRestaurantes;


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
       /* public async Task<PratoRestaurante> GetPratoByNomePratoAsync(string nomePrato)
        {
            PratoRestaurante pratorestaurante = await _pratosrestaurantesRepository.GetPratoByNomePratoAsync(nomePrato);

            if (pratorestaurante is null)
            {
                throw new NotFoundException("Prato");
            }

            return pratorestaurante;
        } */

        public async Task<PratoRestaurante> AddPratoAsync(PratoRestaurante pratorestaurante)
        {
            PratoRestaurante pratoExists = await _pratosrestaurantesRepository.GetPratoByIdAsync(pratorestaurante.IdPrato);
            if (pratoExists != null)
            {
                throw new Exception("Prato já existe.");
            }

            if (string.IsNullOrEmpty(pratorestaurante.NomePrato))
            {
                throw new Exception("O prato precisa de um nome.");
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

            // Pass the modified existing entity to the update method
            await _pratosrestaurantesRepository.UpdatePratoAsync(pratorestauranteExists);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
