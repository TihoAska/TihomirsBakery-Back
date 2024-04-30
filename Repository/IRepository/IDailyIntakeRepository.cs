using TihomirsBakery.Models.Nutritions;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IDailyIntakeRepository : IGenericRepository<DailyIntake>
    {
        Task<DailyIntake> GetById(CancellationToken cancellationToken, int id);
        Task<IEnumerable<DailyIntake>> GetByUserId(CancellationToken cancellationToken, int userId);
        Task<IEnumerable<DailyIntake>> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated);
    }
}
