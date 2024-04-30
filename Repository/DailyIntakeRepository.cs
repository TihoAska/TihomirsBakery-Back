using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class DailyIntakeRepository : GenericRepository<DailyIntake>, IDailyIntakeRepository
    {

        public DailyIntakeRepository(IDataContext context) : base(context)
        {
            
        }

        public Task<IEnumerable<DailyIntake>> GetByDateCreated(CancellationToken cancellationToken, DateTime dateCreated)
        {
            throw new NotImplementedException();
        }

        public Task<DailyIntake> GetById(CancellationToken cancellationToken, int id)
        {
            return _query.Where(di => di.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<IEnumerable<DailyIntake>> GetByUserId(CancellationToken cancellationToken, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
