using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models;

namespace TihomirsBakery.Repositories
{
	public class MealRepository : GenericRepository<Meal>, IMealRepository
	{
        public MealRepository(IDataContext context) : base(context)
        {

        }

		public async Task<Meal> GetById(CancellationToken cancellationToken, int id)
		{
			return await _query.Where(meal => meal.Id == id).FirstOrDefaultAsync(cancellationToken);
		}

        public async Task<Meal> GetByName(CancellationToken cancellationToken, string name)
        {
            return await _query.Where(meal => meal.Name == name).FirstOrDefaultAsync(cancellationToken);
        }
	}
}
