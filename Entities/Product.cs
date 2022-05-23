namespace Entities
{
    public class Product
    {
        public int IdProduct { get; set; }

        public char RegistrationType { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool OutOfStock { get; set; }
    }
}