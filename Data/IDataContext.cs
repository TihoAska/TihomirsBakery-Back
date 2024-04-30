using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TihomirsBakery.Models.Meals;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Data
{
    public interface IDataContext : IDisposable
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DailyIntake> DailyIntakes { get; set; }
        public DbSet<MealIntake> MealIntakes { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}