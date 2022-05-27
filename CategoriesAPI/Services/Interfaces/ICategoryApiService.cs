using Categories.API.ViewModels;
using Entities;

namespace Categories.API.Services.Interfaces
{
    public interface ICategoryApiService
    {
        Task<CategoryViewModel> AddCategoryAsync(Category Category);
        Task<CategoryViewModel> AddOrUpdateCategoryAsync(Category Category);
        Task<bool> DeleteCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync(int limit, int page);
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
    }
}
