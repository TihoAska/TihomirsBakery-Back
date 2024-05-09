using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Repository.IRepository;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Services
{
    public class DailyIntakeService : IDailyIntakeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DailyIntakeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DailyIntake> Get(CancellationToken cancellationToken)
        {
            return await _unitOfWork.DailyIntakes.GetByDateCreated(cancellationToken, DateTime.Now);
        }

        public async Task<DailyIntake> GetByUserIdForToday(CancellationToken cancellationToken, int userId)
        {
            return await _unitOfWork.DailyIntakes.GetByUserIdForToday(cancellationToken, userId);
        }
    }
}
