using TihomirsBakery.Repositories;
using TihomirsBakery.Data;

namespace TihomirsBakery.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMealRepository Meal { get; private set; }

        private readonly IDataContext _context;

        public UnitOfWork(IDataContext dataContext)
        {
            _context = dataContext;
            Meal = new MealRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}