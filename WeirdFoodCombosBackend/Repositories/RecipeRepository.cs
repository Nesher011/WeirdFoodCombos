using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Ingredient> ingredientsTable;
        public DbSet<Step> stepsTable;

        public RecipeRepository(WeirdFoodCombosContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<List<RecipeDto>> GetAll()
        {
            return _mapper.Map<List<RecipeDto>>(await _dbContext.Recipies
                .Include(e => e.Ingredients)
                .Include(e => e.Steps)
                .ToListAsync());
        }

        public override async Task Delete(Guid id)
        {
            var entity = await table.Include(e => e.Ingredients)
                .Include(e => e.Steps).FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                table.Remove(entity);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}