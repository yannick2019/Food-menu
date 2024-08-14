using FoodMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Data
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
                        ImageUrl = "https://fr.ooni.com/cdn/shop/articles/Margherita-9920.jpg?crop=center&height=800&v=1644590066&width=800"
                    },
                    new Dish
                    {
                        Id = 2,
                        Name = "Mozarella",
                        Price = 8.50,
                        ImageUrl = "https://www.galbani.fr/wp-content/uploads/2018/12/pizza_facon_caprese.jpg"
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
                    new DishIngredient { DishId = 2, IngredientId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}