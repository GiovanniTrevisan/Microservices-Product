using AutoMapper;
using Categories.API.Services.Interfaces;
using Categories.API.ViewModels;
using Entities;
using Infrastructure.Abstractions.Repositories;

namespace Categories.API.Services

{
    public class CategoryApiService : ICategoryApiService
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApiService(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = CategoryRepository;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync(int limit, int page)
        {
            var categories = await _categoryRepository.GetAllAsync(limit, page);

            var categoriesView = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return categoriesView;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            CategoryViewModel savedCategory = _mapper.Map<CategoryViewModel>(
                await _categoryRepository.GetCategoryByIdAsync(id)
                );

            return savedCategory;
        }

        public async Task<CategoryViewModel> AddCategoryAsync(Category Category)
        {
            CategoryViewModel savedCategory = _mapper.Map<CategoryViewModel>(
                await _categoryRepository.AddCategoryAsync(Category)
                );

            return savedCategory;
        }

        public async Task<CategoryViewModel> AddOrUpdateCategoryAsync(Category category)
        {
            CategoryViewModel savedCategory = _mapper.Map<CategoryViewModel>(
                await _categoryRepository.AddOrUpdateCategoryAsync(category)
                );

            return savedCategory;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id); ;
        }
    }
}
