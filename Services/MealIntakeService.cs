using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Models.Nutritions.AddedMeals;
using TihomirsBakery.Repository.IRepository;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Services
{
    public class MealIntakeService : IMealIntakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly IHttpContextAccessor _httpContext;

        public MealIntakeService(IUnitOfWork unitOfWork, IMapper autoMapper, IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _httpContext = httpContext;

        }

        public async Task<MealIntake> Create(CancellationToken cancellationToken, MealIntakeCreateRequest createRequest)
        {
            var newMealIntake = _autoMapper.Map<MealIntake>(createRequest);

            var dailyIntakeFromDb = await _unitOfWork.DailyIntakes.GetByUserIdForToday(cancellationToken, int.Parse(_httpContext.HttpContext.User.FindFirstValue("Id")));

            if(dailyIntakeFromDb == null)
            {
                var dailyIntake = new DailyIntake();

                dailyIntake.DateCreated = DateTime.Now.ToUniversalTime();
                dailyIntake.TotalCalories += newMealIntake.Calories;
                dailyIntake.TotalCarbs += newMealIntake.Carbs;
                dailyIntake.TotalFats += newMealIntake.Fats;
                dailyIntake.TotalProtein += newMealIntake.Protein;
                dailyIntake.UserId = int.Parse(_httpContext.HttpContext.User.FindFirstValue("Id"));

                _unitOfWork.DailyIntakes.Add(dailyIntake);

                await _unitOfWork.SaveChangesAsync();

                newMealIntake.DailyIntakeId = dailyIntake.Id;
            }
            else
            {
                dailyIntakeFromDb.TotalCalories += newMealIntake.Calories;
                dailyIntakeFromDb.TotalCarbs += newMealIntake.Carbs;
                dailyIntakeFromDb.TotalFats += newMealIntake.Fats;
                dailyIntakeFromDb.TotalProtein += newMealIntake.Protein;

                _unitOfWork.DailyIntakes.Update(dailyIntakeFromDb);

                await _unitOfWork.SaveChangesAsync();

                newMealIntake.DailyIntakeId = dailyIntakeFromDb.Id;
            }


            foreach (var addedMeal in newMealIntake.AddedMeals)
            {
                addedMeal.MealType = newMealIntake.MealType;
            }

            _unitOfWork.MealIntakes.Add(newMealIntake);

            await _unitOfWork.SaveChangesAsync();

            return newMealIntake;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MealIntake> Update(CancellationToken cancellationToken, MealIntakeUpdateRequest updateRequest)
        {
            var dailyIntakeFromDb = await _unitOfWork.DailyIntakes.GetByUserIdForToday(cancellationToken, int.Parse(_httpContext.HttpContext.User.FindFirstValue("Id"))) ?? throw new Exception("Daily intake for today doesn't exist!");
            var mealIntakesFromDb = await _unitOfWork.MealIntakes.GetByDailyIntakeId(cancellationToken, dailyIntakeFromDb.Id) ?? throw new Exception("No meals were taken today!");

            var mealIntake = mealIntakesFromDb.Where(mi => mi.MealType == updateRequest.MealType).FirstOrDefault() ?? throw new Exception("Meal for this part of the day was not found!");

            dailyIntakeFromDb.TotalCalories += updateRequest.Calories - mealIntake.Calories;
            dailyIntakeFromDb.TotalFats += updateRequest.Fats - mealIntake.Fats;
            dailyIntakeFromDb.TotalCarbs += updateRequest.Carbs - mealIntake.Carbs;
            dailyIntakeFromDb.TotalProtein += updateRequest.Protein - mealIntake.Protein;

            mealIntake.Calories = updateRequest.Calories;
            mealIntake.Protein = updateRequest.Protein;
            mealIntake.Carbs = updateRequest.Carbs;
            mealIntake.Fats = updateRequest.Fats;
            mealIntake.AddedMeals = _autoMapper.Map<List<AddedMeal>>(updateRequest.AddedMeals);

            foreach (var addedMeal in mealIntake.AddedMeals)
            {
                addedMeal.MealType = mealIntake.MealType;
            }

            if (updateRequest.AddedMeals.Count == 0)
            {
                _unitOfWork.MealIntakes.Remove(mealIntake);

                if(dailyIntakeFromDb.TotalCarbs < 1)
                {
                    _unitOfWork.DailyIntakes.Remove(dailyIntakeFromDb);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return mealIntake;
        }
    }
}
