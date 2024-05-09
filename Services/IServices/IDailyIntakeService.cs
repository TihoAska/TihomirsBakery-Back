using TihomirsBakery.Models.Nutritions;

namespace TihomirsBakery.Services.IServices
{
    public interface IDailyIntakeService
    {
        public Task<DailyIntake> Get(CancellationToken cancellationToken);
        public Task<DailyIntake> GetByUserIdForToday(CancellationToken cancellationToken, int userId);
    }
}
