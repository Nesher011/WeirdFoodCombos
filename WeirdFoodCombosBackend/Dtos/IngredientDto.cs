﻿namespace WeirdFoodCombosBackend.Dtos
{
    public class IngredientDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public Guid RecipeId { get; set; }
    }
}