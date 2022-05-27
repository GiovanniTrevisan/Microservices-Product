using Categories.Infrastructure.Context;
using Categories.Infrastructure.Repository.Interface;
using Entities;
using Products.Infrastructure.Utils;

namespace Categories.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly CategoryContext _categoryContext;

        public CategoryRepository(CategoryContext productContext)
        {
            _categoryContext = productContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int limit = 0, int page = 0)
        {
            if (page == 0)
                page = 1;

            if (limit == 0)
                limit = int.MaxValue;

            var skip = (page - 1) * limit;

            return _categoryContext.Category.Skip(skip).Take(limit).ToList();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return _categoryContext.Category.Single(product => product.Id == id);
        }

        public async Task<Category> AddCategoryAsync(Category product)
        {
            product.Id = 0;
            _categoryContext.Add(product);
            _categoryContext.SaveChanges();

            return product;
        }

        public async Task<Category> AddOrUpdateCategoryAsync(Category product)
        {
            _categoryContext.InsertOrUpdate(product);
            _categoryContext.SaveChanges();

            return product;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var product = _categoryContext.Category.Single(product => product.Id == id);
                _categoryContext.Category.Remove(product);
                _categoryContext.SaveChanges();

            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
