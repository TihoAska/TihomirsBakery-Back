using TihomirsBakery.Models.Workout;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IWorkoutRepository : IGenericRepository<Workout>
    {
        public Task<Workout> GetById(int id, CancellationToken cancellationToken);
        public Task<Workout> GetByUserId(int userId, CancellationToken cancellationToken);
        public Task<Workout> GetWorkoutForTodayByUserId(int userId, CancellationToken cancellationToken);
    }
}
