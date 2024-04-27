using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TihomirsBakery.Models.Meal;
using TihomirsBakery.Models.User;

namespace TihomirsBakery.Data
{
    public interface IDataContext : IDisposable
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}