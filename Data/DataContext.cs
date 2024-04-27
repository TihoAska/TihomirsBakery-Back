using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TihomirsBakery.Models.Meal;
using TihomirsBakery.Models.User;

namespace TihomirsBakery.Data
{
	public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>, IDataContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
				
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseNpgsql("Server=localhost;Database=mydatabase2;Port=5432;User Id=myuser2;Password=mypassword2;Pooling=true;Maximum Pool Size=3;Minimum Pool Size=1;");
		}
	}
}
