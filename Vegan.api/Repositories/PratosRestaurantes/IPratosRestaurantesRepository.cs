using Vegan.api.Models;

namespace Vegan.api.Repositories.PratosRestaurantes
{
    public interface IPratosRestaurantesRepository
    {
        public Task<IEnumerable<PratoRestaurante>> GetAllPratosAsync();
        public Task<PratoRestaurante> GetPratoByIdAsync(int id);
        public Task AddPratoAsync(PratoRestaurante pratorestaurante);
        public Task DeletePrato(PratoRestaurante pratorestaurante);
        public Task UpdatePratoAsync(PratoRestaurante pratorestaurante);

    }
}
