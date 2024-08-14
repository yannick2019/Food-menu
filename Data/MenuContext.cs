using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(d => new
                {
                    d.DishId,
                    d.IngredientId
                });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(i => i.IngredientId);

            // fill Dish table in database
            modelBuilder.Entity<Dish>()
                .HasData(
                    new Dish
                    {
                        Id = 1,
                        Name = "Margherita",
                        Price = 7.50,
                        ImageUrl = "https://www.eataly.com/us_en/magazine/recipes/pizza-and-focaccia-recipes/pizza-margherita"
                    }
                );

            // fill Ingredient table in database
            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient { Id = 1, Name = "Tomato, sauce" },
                    new Ingredient { Id = 2, Name = "Mozarella" }
                );

            // fill DishIngredient table
            modelBuilder.Entity<DishIngredient>()
                .HasData(
                    new DishIngredient { DishId = 1, IngredientId = 1 },
                    new DishIngredient { DishId = 1, IngredientId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}