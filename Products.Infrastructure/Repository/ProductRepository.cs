using Entities;
using Products.Infrastructure.Context;
using Products.Infrastructure.Interfaces;

namespace Products.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _productContext;

        public ProductRepository()
        {
        }

        public async Task<List<Product>> GetAllAsync(int limit, int page)
        {

        }
    }
}
