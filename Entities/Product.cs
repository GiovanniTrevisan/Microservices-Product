namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool OutOfStock { get; set; }

        public Category Category { get; set; }
    }
}