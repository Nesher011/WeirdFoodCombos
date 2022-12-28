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

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetById(Guid id)
        {
            return await _recipeRepository.GetById(id) is RecipeDto r ? Ok(r) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> Create([FromBody] RecipeDto recipeDto)
        {
            var recipe = await _recipeRepository.Create(recipeDto);
            if (recipe == null)
                return BadRequest();

            return Ok(recipe);
        }

        [HttpPut]
        public async Task<ActionResult<Recipe>> Update([FromBody] RecipeDto recipeDto)
        {
            var recipe = await _recipeRepository.Update(recipeDto);

            if (recipe == null)
                return BadRequest();

            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _recipeRepository.Delete(id);
            return NoContent();
        }
    }
}