using TihomirsBakery.Models.Meal;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<Meal> GetById(CancellationToken cancellationToken, int id);
        Task<List<Meal>> GetByName(CancellationToken cancellationToken, string name);
    }
}
