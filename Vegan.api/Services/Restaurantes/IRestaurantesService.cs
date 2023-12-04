using Vegan.api.Models;

namespace Vegan.api.Services.Restaurantes
{
    public interface IRestaurantesService
    {
        public Task<IEnumerable<Restaurante>> GetAllRestaurantesAsync();
        public Task<Restaurante> GetRestauranteByIdAsync(int id);
        public Task<Restaurante> GetRestauranteByNomeResAsync(string nome);
        public Task<Restaurante> AddRestauranteAsync(Restaurante restaurante);
        public Task DeleteRestauranteAsync(int id);
        public Task UpdateRestauranteAsync(int id, Restaurante restaurante);
    }
}
