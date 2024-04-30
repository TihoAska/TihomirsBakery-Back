using AutoMapper;
using TihomirsBakery.Models.Meals;
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
        }
    }
}