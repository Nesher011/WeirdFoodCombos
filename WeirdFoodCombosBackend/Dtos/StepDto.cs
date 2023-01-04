using WeirdFoodCombosBackend.Entities;

namespace WeirdFoodCombosBackend.Dtos
{
    public class StepDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

    }
}