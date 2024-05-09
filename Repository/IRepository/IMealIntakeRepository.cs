using TihomirsBakery.Models.Nutritions;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IMealIntakeRepository : IGenericRepository<MealIntake>
    {
        Task<MealIntake> GetById(CancellationToken cancellationToken, int id);
        Task<List<MealIntake>> GetByDailyIntakeId(CancellationToken cancellationToken, int userId);
        Task<List<MealIntake>> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated);
    }
}
