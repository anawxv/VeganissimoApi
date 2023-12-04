using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegan.api.Data;

namespace Vegan.api.Repositories.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
