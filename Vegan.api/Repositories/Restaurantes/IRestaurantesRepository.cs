
using Vegan.api.Models;

namespace Vegan.api.Repositories.Restaurantes
{
    public interface IRestaurantesRepository
    {
        public Task<IEnumerable<Restaurante>> GetAllRestaurantesAsync();
        public Task<Restaurante> GetRestauranteByIdAsync(int id);
        public Task AddRestauranteAsync(Restaurante restaurante);
        public Task DeleteRestaurante(Restaurante restaurante);
        public Task UpdateRestauranteAsync(Restaurante restaurante);
    }
}
