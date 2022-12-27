using AutoMapper;
using WeirdFoodCombosBackend.Databases;
using WeirdFoodCombosBackend.Dtos;
using WeirdFoodCombosBackend.Entities;
using WeirdFoodCombosBackend.Interfaces;

namespace WeirdFoodCombosBackend.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe, RecipeDto>, IRecipeRepository
    {
        private readonly WeirdFoodCombosContext _dbContext;
        private readonly IMapper _mapper;
        public RecipeRepository(WeirdFoodCombosContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
