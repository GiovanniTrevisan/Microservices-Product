namespace WebFront.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool OutOfStock { get; set; }

        public int IdCategory { get; set; }

        public CategoryViewModel? Category { get; set; }
    }
}