using Microsoft.EntityFrameworkCore;
using WeirdFoodCombosBackend.Entities;

namespace WeirdFoodCombosBackend.Databases
{
    public class WeirdFoodCombosContext : DbContext
    {
        public DbSet<Recipe> Recipies => Set<Recipe>();

        public WeirdFoodCombosContext(DbContextOptions<WeirdFoodCombosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .HasKey(e => new { e.Id, e.RecipeId });
            modelBuilder.Entity<Step>()
                .HasKey(e => new { e.Id, e.RecipeId });
            base.OnModelCreating(modelBuilder);
        }
    }
}