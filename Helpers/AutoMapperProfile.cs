using AutoMapper;
using TihomirsBakery.Models;

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
        }
    }
}