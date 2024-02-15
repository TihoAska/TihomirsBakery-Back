using TihomirsBakery.Models;

namespace TihomirsBakery.Repositories
{
	public interface IMealRepository : IGenericRepository<Meal>
	{
		Task<Meal> GetById(CancellationToken cancellationToken, int id);
        Task<Meal> GetByName(CancellationToken cancellationToken, string name);
	}
}
