using Vegan.api.Models;

namespace Vegan.api.Services.PratosRestaurantes
{
    public interface IPratosRestaurantesService
    {
        public Task<IEnumerable<PratoRestaurante>> GetAllPratosAsync();
        public Task<PratoRestaurante> GetPratoByIdAsync(int id);
        public Task<PratoRestaurante> AddPratoAsync(PratoRestaurante pratorestaurante);
        public Task DeletePratoAsync(int id);
        public Task UpdatePratoAsync(int id, PratoRestaurante pratorestaurante);
    }
}
