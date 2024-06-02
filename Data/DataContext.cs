using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TihomirsBakery.Models.Meals;
using TihomirsBakery.Models.Users;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Models.Nutritions.AddedMeals;
using TihomirsBakery.Models.Workout;

namespace TihomirsBakery.Data
{
	public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>, IDataContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DailyIntake> DailyIntakes { get; set; }
        public DbSet<MealIntake> MealIntakes { get; set; }
        public DbSet<AddedMeal> AddedMeals { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            base.OnConfiguring(optionsBuilder);
		}
	}
}
