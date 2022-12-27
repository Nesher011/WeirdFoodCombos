using Microsoft.AspNetCore.Mvc;
using WeirdFoodCombosBackend.Dtos;
using WeirdFoodCombosBackend.Entities;
using WeirdFoodCombosBackend.Interfaces;
using WeirdFoodCombosBackend.Repositories;

namespace WeirdFoodCombosBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetAll()
        {
            return Ok(await _recipeRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> Create([FromBody] RecipeDto recipeDto)
        {
            var recipe = await _recipeRepository.Create(recipeDto);
            if (recipe == null)
                throw new NotImplementedException();

            return Ok(recipe);
        }
    }
}
