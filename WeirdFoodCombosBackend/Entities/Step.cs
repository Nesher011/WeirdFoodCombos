namespace WeirdFoodCombosBackend.Entities
{
    public class Step : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid RecipeId { get; set; }
    }
}