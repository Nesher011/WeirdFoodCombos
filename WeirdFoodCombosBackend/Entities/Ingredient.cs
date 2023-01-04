namespace WeirdFoodCombosBackend.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public Guid RecipeId { get; set; }
    }
}