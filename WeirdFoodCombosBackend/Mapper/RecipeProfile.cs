using AutoMapper;
using WeirdFoodCombosBackend.Dtos;
using WeirdFoodCombosBackend.Entities;

namespace WeirdFoodCombosBackend.Mapper
{
    public class RecipeProfile:Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeDto, Recipe>().ReverseMap();
        }
    }
}
