using TihomirsBakery.Models.Nutritions;

namespace TihomirsBakery.Services.IServices
{
    public interface IMealIntakeService
    {
        Task<MealIntake> Create(CancellationToken cancellationToken, MealIntakeCreateRequest createRequest);
        Task<MealIntake> Update(CancellationToken cancellationToken, MealIntakeUpdateRequest updateRequest);
        Task<bool> Delete(int id);
    }
}
