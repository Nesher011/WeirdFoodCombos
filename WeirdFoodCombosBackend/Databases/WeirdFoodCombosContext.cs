using Microsoft.EntityFrameworkCore;
using WeirdFoodCombosBackend.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WeirdFoodCombosBackend.Databases
{
    public class WeirdFoodCombosContext : DbContext
    {
        public DbSet<Recipe> Recipies => Set<Recipe>();

        public WeirdFoodCombosContext(DbContextOptions<WeirdFoodCombosContext> options) : base(options)
        {
        }
    }
}