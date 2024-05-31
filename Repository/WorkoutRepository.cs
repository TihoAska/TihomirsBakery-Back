using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Workout;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class WorkoutRepository : GenericRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(IDataContext context) : base(context)
        {
            
        }

        public Task<Workout> GetById(int id, CancellationToken cancellationToken)
        {
            return _query.Where(wk => wk.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<Workout> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            return _query.Where(wk => wk.UserId == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<Workout> GetWorkoutForTodayByUserId(int userId, CancellationToken cancellationToken)
        {
            var now = DateTime.Now.ToUniversalTime();
            var dayStart = now.Date;
            var dayEnd = dayStart.AddDays(1);

            return _query.Where(wk => wk.UserId == userId && wk.DateCreated >= dayStart && wk.DateCreated < dayEnd)
                .Include(wk => wk.User)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
