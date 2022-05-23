using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Products.Infrastructure.Context
{
    public class ProductContext : EntityContext
    {
        private readonly IConfiguration _configuration;

        public ProductContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public IDbConnection ProductConnection
        {
            get
            {
                return new MySqlConnection(_configuration["ConnectionStrings:SqlConnectionString"]);
            }
        }

        //Entities
        public DbSet<Product> Products { get; set; }
    }
}
