namespace Menu.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double Price { get; set; }
    }
}