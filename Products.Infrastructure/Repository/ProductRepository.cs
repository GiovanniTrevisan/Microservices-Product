using Entities;
using Products.Infrastructure.Context;
using Products.Infrastructure.Interfaces;
using Products.Infrastructure.Utils;

namespace Products.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly EntityContext _productContext;

        public ProductRepository(EntityContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int limit = 0, int page = 0)
        {
            if (page == 0)
                page = 1;

            if (limit == 0)
                limit = int.MaxValue;

            var skip = (page - 1) * limit;

            return _productContext.Products.Skip(skip).Take(limit).ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return _productContext.Products.Single(product => product.Id == id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            product.Id = 0;
            _productContext.Add(product);
            _productContext.SaveChanges();

            return product;
        }

        public async Task<Product> AddOrUpdateProductAsync(Product product)
        {
            _productContext.InsertOrUpdate(product);
            _productContext.SaveChanges();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = _productContext.Products.Single(product => product.Id == id);
                _productContext.Products.Remove(product);
                _productContext.SaveChanges();

            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
