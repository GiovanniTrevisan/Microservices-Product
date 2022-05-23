using Products.API.Services.Interfaces;
using Products.API.ViewModels;
using Products.Infrastructure.Interfaces;

namespace Products.API.Services

{
    public class ProductApiService : IProductApiService
    {
        private readonly IProductRepository _productRepository;

        public ProductApiService(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<List<ProductViewModel>> GetAllProductsAsync(int limit, int page)
        {
            var products = await _productRepository.GetAllAsync(limit, page);

            return products;
        }
    }
}
