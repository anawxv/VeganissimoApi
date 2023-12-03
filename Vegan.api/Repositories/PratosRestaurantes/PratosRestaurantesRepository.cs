using Vegan.api.Data;
using Vegan.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vegan.api.Repositories.PratosRestaurantes
{
    public class PratosRestaurantesRepository : IPratosRestaurantesRepository
    {
        private readonly DataContext _dataContext;
        public PratosRestaurantesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<PratoRestaurante>> GetAllPratosAsync()
        {
            return await _dataContext.PratoRestaurantes.ToListAsync();
        }

        public async Task<PratoRestaurante> GetPratoByIdAsync(int id)
        {
            return await _dataContext.PratoRestaurantes.FirstOrDefaultAsync(p => p.IdPrato == id);
        }

        public async Task AddPratoAsync(PratoRestaurante pratorestaurante)
        {
            await _dataContext.PratoRestaurantes.AddAsync(pratorestaurante);
        }

        public async Task DeletePrato(PratoRestaurante pratorestaurante)
        {
            _dataContext.PratoRestaurantes.Remove(pratorestaurante);
        }

        public async Task UpdatePratoAsync(PratoRestaurante pratorestaurante)
        {
            _dataContext.Update(pratorestaurante);
        }

       /* public async Task<PratoRestaurante> FindUserByEmailAsync(string email)
        {
            return await _dataContext.Fornecedors.FirstOrDefaultAsync(c => c.Email == email);
        } */
    }
}

