namespace FoodMenu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double Price { get; set; }
        public List<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
    }
}