using TihomirsBakery.Repositories;

namespace TihomirsBakery.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMealRepository Meal { get; }
        Task<int> SaveChangesAsync();
    }
}