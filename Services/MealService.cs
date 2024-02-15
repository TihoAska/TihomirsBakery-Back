using AutoMapper;
using TihomirsBakery.Models;
using TihomirsBakery.UnitOfWork;

namespace TihomirsBakery.Services
{
	public class MealService : IMealService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public MealService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
		}

		public async Task<IEnumerable<Meal>> GetAll(CancellationToken cancellationToken)
		{
            var mealsFromDb = await _unitOfWork.Meal.GetAll(cancellationToken);

			return mealsFromDb ?? throw new Exception("No meals were found!");
		}

		public async Task<Meal> GetById(CancellationToken cancellationToken, int id)
		{
            var mealFromDb = await _unitOfWork.Meal.GetById(cancellationToken, id);

			return mealFromDb ?? throw new Exception("Meal with the given ID was not found!");
		}

		public async Task<Meal> Create(CancellationToken cancellationToken, MealCreateRequest meal)
		{
            var newMeal = _mapper.Map<Meal>(meal);

			_unitOfWork.Meal.Add(newMeal);
            await _unitOfWork.SaveChangesAsync();

			return newMeal;
		}

		public async Task<bool> Delete(CancellationToken cancellationToken, int id)
		{
			var mealFromDb = await _unitOfWork.Meal.GetById(cancellationToken, id) ?? throw new Exception("Meal with the given ID was not found!");
            
            _unitOfWork.Meal.Remove(mealFromDb);
            await _unitOfWork.SaveChangesAsync();

			return true;
		}

		public async Task<Meal> Update(CancellationToken cancellationToken, MealUpdateRequest request)
		{
			var mealFromDb = await _unitOfWork.Meal.GetById(cancellationToken, request.Id) ?? throw new Exception("Meal not found!");
            
            mealFromDb.Name = request.Name;
			mealFromDb.Type = request.Type;
			mealFromDb.Description = request.Description;
			mealFromDb.Proteins = request.Proteins;
			mealFromDb.Carbs = request.Carbs;
			mealFromDb.Fats = request.Fats;

            await _unitOfWork.SaveChangesAsync();

			return mealFromDb;
		}
	}
}
