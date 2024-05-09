using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class DailyIntakeRepository : GenericRepository<DailyIntake>, IDailyIntakeRepository
    {

        public DailyIntakeRepository(IDataContext context) : base(context)
        {
            
        }

        public Task<DailyIntake> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated)
        {
            var now = DateTime.Now.ToUniversalTime();
            var dayStart = now.Date;
            var dayEnd = dayStart.AddDays(1);

            return _query.Where(di => di.DateCreated >= dayStart && di.DateCreated < dayEnd)
                .Include(di => di.User)
                .Include(di => di.MealIntakes)
                .ThenInclude(mi => mi.AddedMeals)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<DailyIntake> GetById(CancellationToken cancellationToken, int id)
        {
            return _query.Where(di => di.Id == id)
                .Include(di => di.User)
                .Include(di => di.MealIntakes)
                .ThenInclude(mi => mi.AddedMeals)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<DailyIntake> GetByUserIdForToday(CancellationToken cancellationToken, int userId)
        {
            var now = DateTime.Now.ToUniversalTime();
            var dayStart = now.Date;
            var dayEnd = dayStart.AddDays(1);

            return _query.Where(di => di.UserId == userId && di.DateCreated >= dayStart && di.DateCreated < dayEnd)
                .Include(di => di.User)
                .Include(di => di.MealIntakes)
                .ThenInclude(mi => mi.AddedMeals)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
