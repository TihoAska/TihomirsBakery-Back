using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.Nutritions.AddedMeals;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class AddedMealRepository : GenericRepository<AddedMeal>, IAddedMealRepository
    {
        public AddedMealRepository(IDataContext context) : base(context)
        {

        }


    }
}
