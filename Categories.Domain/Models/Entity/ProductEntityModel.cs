using System.ComponentModel.DataAnnotations;

namespace Categories.Domain.Models.Entity
{
    public class CategoryEntityModel
    {
        public CategoryEntityModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Required(ErrorMessage = "Required ID")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
