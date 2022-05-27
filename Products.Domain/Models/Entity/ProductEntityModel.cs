using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Models.Entity
{
    public class ProductEntityModel
    {
        public ProductEntityModel(int id, string name, string description, bool outOfStock)
        {
            Id = id;
            Name = name;
            Description = description;
            OutOfStock = outOfStock;
        }

        [Required(ErrorMessage = "Required ID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool OutOfStock { get; set; }

    }
}
