﻿using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
             : base(options) { }


        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Category { get; set; }

    }
}
