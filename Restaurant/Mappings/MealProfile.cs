using AutoMapper;
using Restaurant.DataAccess.Entities;

namespace Restaurant.Mappings
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealDto>().ReverseMap();
        }
    }
}
