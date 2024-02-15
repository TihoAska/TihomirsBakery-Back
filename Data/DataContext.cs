using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Models;

namespace TihomirsBakery.Data
{
	public class DataContext : DbContext, IDataContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
				
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseNpgsql("Server=localhost;Database=mydatabase;Port=5431;User Id=myuser;Password=mypassword;Pooling=true;Maximum Pool Size=3;Minimum Pool Size=1;");
		}

		public DbSet<Meal> Meals { get; set; }
	}
}
