using AutoMapper;
using TihomirsBakery.Models.Meals;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Models.Nutritions.AddedMeals;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MealCreateRequest, Meal>();

            CreateMap<MealUpdateRequest, Meal>();

            CreateMap<UserCreateRequest, User>();

            CreateMap<UserUpdateRequest, User>();

            CreateMap<MealIntakeCreateRequest, MealIntake>()
                .ForMember(d => d.AddedMeals, opt => opt.MapFrom(s => s.AddedMeals.Select(am => new AddedMeal()
                {
                    Name = am.Name,
                    MealType = am.MealType,
                    MealIntakeId = am.MealIntakeId,
                    Calories = am.Calories,
                    Carbs = am.Carbs,
                    Protein = am.Protein,
                    Fats = am.Fats,
                })));

            CreateMap<MealIntakeUpdateRequest, MealIntake>()
                .ForMember(d => d.AddedMeals, opt => opt.MapFrom(s => s.AddedMeals.Select(am => new AddedMeal()
                {
                    Name = am.Name,
                    MealType = am.MealType,
                    MealIntakeId = am.MealIntakeId,
                    Calories = am.Calories,
                    Carbs = am.Carbs,
                    Protein = am.Protein,
                    Fats = am.Fats,
                })));

            CreateMap<AddedMealCreateRequest, AddedMeal>();
        }
    }
}