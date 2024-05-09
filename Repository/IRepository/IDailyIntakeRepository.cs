using TihomirsBakery.Models.Nutritions;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IDailyIntakeRepository : IGenericRepository<DailyIntake>
    {
        Task<DailyIntake> GetById(CancellationToken cancellationToken, int id);
        Task<DailyIntake> GetByUserIdForToday(CancellationToken cancellationToken, int userId);
        Task<DailyIntake> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated);
    }
}
