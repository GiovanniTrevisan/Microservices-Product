using Entities;

namespace Infrastructure.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category product);
        Task<Category> AddOrUpdateCategoryAsync(Category product);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync(int limit = 0, int page = 0);
        Task<Category> GetCategoryByIdAsync(int id);
    }
}