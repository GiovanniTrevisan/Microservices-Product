using Entities;
using Products.API.ViewModels;

namespace Products.API.Services.Interfaces
{
    public interface IProductApiService
    {
        Task<bool> DeleteProductByIdAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(int limit, int page);
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task<ProductViewModel> AddProductAsync(Product product);
        Task<ProductViewModel> AddOrUpdateProductAsync(Product product);
    }
}
