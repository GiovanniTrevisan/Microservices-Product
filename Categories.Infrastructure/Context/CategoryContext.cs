using Entities;
using Microsoft.EntityFrameworkCore;

namespace Categories.Infrastructure.Context
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
             : base(options) { }

        public DbSet<Category> Category { get; set; }

    }
}
