using System.ComponentModel.DataAnnotations;

namespace WeirdFoodCombosBackend.Entities
{
    public class Recipe:BaseEntity
    {
        public string Name { get; set; }
        [Range(0,5)]
        public int Difficulty { get; set; }
    }
}
