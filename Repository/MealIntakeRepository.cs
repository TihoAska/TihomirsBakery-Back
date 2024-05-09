using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class MealIntakeRepository : GenericRepository<MealIntake>, IMealIntakeRepository
    {
        public MealIntakeRepository(IDataContext context) : base(context)
        {

        }

        public Task<List<MealIntake>> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated)
        {
            throw new NotImplementedException();
        }

        public Task<MealIntake> GetById(CancellationToken cancellationToken, int id)
        {
            return _query.Where(mi => mi.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<MealIntake>> GetByDailyIntakeId(CancellationToken cancellationToken, int dailyIntakeId)
        {
            return _query.Where(mi => mi.DailyIntakeId == dailyIntakeId).ToListAsync(cancellationToken);
        }
    }
}
