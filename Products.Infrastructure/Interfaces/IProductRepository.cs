using Entities;

namespace Products.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddOrUpdateProductAsync(Product product);
        Task<Product> AddProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync(int limit = 0, int page = 0);
        Task<Product> GetProductByIdAsync(int id);
    }
}