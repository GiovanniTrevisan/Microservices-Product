using Products.API.ViewModels;

namespace Products.API.Services.Interfaces
{
    public interface IProductApiService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync(int limit, int page);
    }
}
