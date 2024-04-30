using TihomirsBakery.Repositories;
using TihomirsBakery.Data;
using TihomirsBakery.Repository.IRepository;
using System.Security.Cryptography.X509Certificates;

namespace TihomirsBakery.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;
        public IMealRepository Meals { get; private set; }
        public IUserRepository Users { get; private set; }
        public IDailyIntakeRepository DailyIntake { get; private set; }
        

        public UnitOfWork(IDataContext dataContext)
        {
            _context = dataContext;
            Meals = new MealRepository(_context);
            Users = new UserRepository(_context);
            DailyIntake = new DailyIntakeRepository(_context);
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