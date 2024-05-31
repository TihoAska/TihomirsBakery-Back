namespace TihomirsBakery.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMealRepository Meals { get; }
        IUserRepository Users { get; }
        IMealIntakeRepository MealIntakes { get; }
        IDailyIntakeRepository DailyIntakes { get; }
        IAddedMealRepository AddedMeals { get; }
        IWorkoutRepository Workouts { get; }
        Task<int> SaveChangesAsync();
    }
}