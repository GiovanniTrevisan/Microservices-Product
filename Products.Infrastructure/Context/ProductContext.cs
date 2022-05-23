using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Products.Infrastructure.Context
{
    public class ProductContext
    {
        private readonly IConfiguration _configuration;

        public ProductContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ProductConnection
        {
            get
            {
                return new MySqlConnection(_configuration["ConnectionStrings:SqlConnectionString"]);
            }
        }        
    }
}
