using AutoMapper;
using TihomirsBakery.Models.Meals;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MealCreateRequest, Meal>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Proteins, opt => opt.MapFrom(s => s.Proteins))
                .ForMember(d => d.Fats, opt => opt.MapFrom(s => s.Fats))
                .ForMember(d => d.Carbs, opt => opt.MapFrom(s => s.Carbs));

            CreateMap<MealUpdateRequest, Meal>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Proteins, opt => opt.MapFrom(s => s.Proteins))
                .ForMember(d => d.Fats, opt => opt.MapFrom(s => s.Fats))
                .ForMember(d => d.Carbs, opt => opt.MapFrom(s => s.Carbs));

            CreateMap<UserCreateRequest, User>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email));

            CreateMap<UserUpdateRequest, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email));
        }
    }
}