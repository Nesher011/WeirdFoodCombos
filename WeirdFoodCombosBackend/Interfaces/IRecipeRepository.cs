using WeirdFoodCombosBackend.Dtos;
using WeirdFoodCombosBackend.Entities;

namespace WeirdFoodCombosBackend.Interfaces
{
    public interface IRecipeRepository : IBaseRepository<Recipe, RecipeDto>
    {
    }
}