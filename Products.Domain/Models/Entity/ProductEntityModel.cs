using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Models.Entity
{
    public class ProductEntityModel
    {
        public ProductEntityModel(int idProduct, string name, string description, bool outOfStock)
        {
            IdProduct = idProduct;
            Name = name;
            Description = description;
            OutOfStock = outOfStock;
        }

        [Required(ErrorMessage = "Required ID")]
        public int IdProduct { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool OutOfStock { get; set; }

    }
}
