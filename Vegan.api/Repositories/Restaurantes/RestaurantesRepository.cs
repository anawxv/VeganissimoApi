using Vegan.api.Data;
using Vegan.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vegan.api.Repositories.Restaurantes
{
    public class RestaurantesRepository : IRestaurantesRepository
    {
        private readonly DataContext _dataContext;
        public RestaurantesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Restaurante>> GetAllRestaurantesAsync()
        {
            return await _dataContext.Restaurantes.ToListAsync();
        }

        public async Task<Restaurante> GetRestauranteByIdAsync(int id)
        {
            return await _dataContext.Restaurantes.FirstOrDefaultAsync(r => r.IdRes == id);
        }
        public async Task<Restaurante> GetRestauranteByNomeResAsync(string nome)
        {
            return await _dataContext.Restaurantes.FirstOrDefaultAsync(r => r.NomeRes == nome);
        }

        public async Task AddRestauranteAsync(Restaurante restaurante)
        {
            await _dataContext.Restaurantes.AddAsync(restaurante);
        }

        public async Task DeleteRestaurante(Restaurante restaurante)
        {
            _dataContext.Restaurantes.Remove(restaurante);
        }

        public async Task UpdateRestauranteAsync(Restaurante restaurante)
        {
            _dataContext.Update(restaurante);
        }

    }
}
