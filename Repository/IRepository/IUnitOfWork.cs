namespace TihomirsBakery.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMealRepository Meals { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}