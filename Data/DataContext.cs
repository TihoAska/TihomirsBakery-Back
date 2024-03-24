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
			optionsBuilder.UseNpgsql("Server=localhost;Database=mydatabase2;Port=5432;User Id=myuser2;Password=mypassword2;Pooling=true;Maximum Pool Size=3;Minimum Pool Size=1;");
		}

		public DbSet<Meal> Meals { get; set; }
	}
}
