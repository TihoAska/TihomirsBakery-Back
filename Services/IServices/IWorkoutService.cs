using TihomirsBakery.Models.Workout;

namespace TihomirsBakery.Services.IServices
{
    public interface IWorkoutService
    {
        public Task<IEnumerable<Workout>> GetAll(CancellationToken cancellationToken);
        public Task<Workout> GetById(int id, CancellationToken cancellationToken);
        public Task<Workout> GetByUserId(int userId, CancellationToken cancellationToken);
        public Task<Workout> GetWorkoutForTodayByUserId(int userId, CancellationToken cancellationToken);
        public Task<Workout> Create(WorkoutCreateRequest createRequest, CancellationToken cancellationToken);
        public Task<Workout> Update(WorkoutUpdateRequest updateRequest, CancellationToken cancellationToken);
        public Task<bool> Delete(int id, CancellationToken cancellationToken);
        public Task<bool> DeleteTodaysWorkoutByUserId(int userId, CancellationToken cancellationToken);
    }
}
