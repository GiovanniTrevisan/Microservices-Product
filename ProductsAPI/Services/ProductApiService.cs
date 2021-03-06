using AutoMapper;
using Entities;
using Infrastructure.Abstractions.Repositories;
using Products.API.Services.Interfaces;
using Products.API.ViewModels;

namespace Products.API.Services

{
    public class ProductApiService : IProductApiService
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductApiService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(int limit, int page)
        {
            var products = await _productRepository.GetAllAsync(limit, page);

            IEnumerable<ProductViewModel> productsViews = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return productsViews;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            ProductViewModel savedProduct = _mapper.Map<ProductViewModel>(await _productRepository.GetProductByIdAsync(id));

            return savedProduct;
        }

        public async Task<ProductViewModel> AddProductAsync(Product product)
        {
            ProductViewModel savedProduct = _mapper.Map<ProductViewModel>(await _productRepository.AddProductAsync(product));

            return savedProduct;
        }

        public async Task<ProductViewModel> AddOrUpdateProductAsync(Product product)
        {
            ProductViewModel savedProduct = _mapper.Map<ProductViewModel>(await _productRepository.AddOrUpdateProductAsync(product));

            return savedProduct;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id); ;
        }
    }
}
