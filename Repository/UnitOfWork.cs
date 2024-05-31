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
        public IDailyIntakeRepository DailyIntakes { get; private set; }
        public IMealIntakeRepository MealIntakes { get; private set; }
        public IAddedMealRepository AddedMeals { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }

        public UnitOfWork(IDataContext dataContext)
        {
            _context = dataContext;
            Meals = new MealRepository(_context);
            Users = new UserRepository(_context);
            DailyIntakes = new DailyIntakeRepository(_context);
            MealIntakes = new MealIntakeRepository(_context);
            AddedMeals = new AddedMealRepository(_context);
            Workouts = new WorkoutRepository(_context);
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