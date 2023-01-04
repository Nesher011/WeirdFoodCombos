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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Ingredient>()
                .HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.RecipeId);
            modelBuilder.Entity<Step>()
                .HasOne(e => e.Recipe)
                .WithMany(e => e.Steps)
                .HasForeignKey(e => e.RecipeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}