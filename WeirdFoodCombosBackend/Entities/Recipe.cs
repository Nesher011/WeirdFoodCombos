using System.ComponentModel.DataAnnotations;

namespace WeirdFoodCombosBackend.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }

        [Range(0, 5)]
        public int Difficulty { get; set; }

        public int TimeNeededInMinutes { get; set; }
        public int Servings { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime Created { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public List<Step>? Steps { get; set; }
    }
}