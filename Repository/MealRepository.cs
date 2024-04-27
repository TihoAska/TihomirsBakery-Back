using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Meal;
using TihomirsBakery.Repository.IRepository;

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

        public async Task<List<Meal>> GetByName(CancellationToken cancellationToken, string name)
        {
            return await _query.Where(meal => meal.Name.ToLower().Contains(name.ToLower())).ToListAsync(cancellationToken);
        }
	}
}
