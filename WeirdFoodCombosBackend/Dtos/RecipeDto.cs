using System.ComponentModel.DataAnnotations;

namespace WeirdFoodCombosBackend.Dtos
{
    public class RecipeDto:BaseDto
    {
        public string Name { get; set; }
        [Range(0, 5)]
        public int Difficulty { get; set; }
    }
}
