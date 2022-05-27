using AutoMapper;
using Categories.API.Services.Interfaces;
using Categories.API.ViewModels;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Categories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICategoryApiService _categoryApiService;

        public CategoriesController(IMapper mapper, ICategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }


        [HttpGet]
        [Route("category/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CategoryViewModel))]
        public async Task<ActionResult> GetCategory([FromRoute] int id)
        {
            if (id == 0)
                return NoContent();

            CategoryViewModel category = await _categoryApiService.GetCategoryByIdAsync(id);

            return Ok(category);
        }

        [HttpGet]
        [Route("category")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CategoryViewModel))]
        public async Task<ActionResult> GetCategoriesAsync([FromRoute] int limit = 0, int page = 0)
        {
            //Optional params for paginations
            IEnumerable<CategoryViewModel>? categories = await _categoryApiService.GetAllCategoriesAsync(limit, page);

            return Ok(categories);
        }

        [HttpPost]
        [Route("category")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CategoryViewModel))]
        public async Task<ActionResult> AddCategory([FromBody] CategoryViewModel categoryViewModel)
        {
            Category category = _mapper.Map<CategoryViewModel, Category>(categoryViewModel);

            CategoryViewModel savedCategory = await _categoryApiService.AddCategoryAsync(category);

            return Ok(savedCategory);
        }

        [HttpPut]
        [Route("category/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CategoryViewModel))]
        public async Task<ActionResult> AddOrUpdateCategory([FromRoute] int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(categoryViewModel);

            var savedCategory = await _categoryApiService.AddOrUpdateCategoryAsync(category);

            return Ok(savedCategory);
        }

        [HttpDelete]
        [Route("category/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(CategoryViewModel))]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id)
        {
            if (id == 0)
                return NoContent();

            bool isDeleted = await _categoryApiService.DeleteCategoryByIdAsync(id);

            return Ok(isDeleted);

        }
    }
}
