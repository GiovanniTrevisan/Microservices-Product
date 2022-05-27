using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Products.API.Services.Interfaces;
using Products.API.ViewModels;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [OpenApiTag("Products", Description = "Product Management")]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductApiService _productsApiService;

        public ProductsController(IMapper mapper, IProductApiService productsApiService)
        {
            _mapper = mapper;
            _productsApiService = productsApiService;
        }

        [HttpGet]
        [Route("product")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> GetProducts([FromRoute] int limit = 0, int page = 0)
        {
            //Optional params for paginations
            var products = await _productsApiService.GetAllProductsAsync(limit, page);

            return Ok(products);
        }

        [HttpGet]
        [Route("product/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> GetProduct([FromRoute] int id)
        {
            if (id == 0)
                return NoContent();

            ProductViewModel product = await _productsApiService.GetProductByIdAsync(id);

            return Ok(product);

        }

        [HttpPost]
        [Route("product")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> AddProduct([FromBody] ProductViewModel productViewModel)
        {
            Product product = _mapper.Map<ProductViewModel, Product>(productViewModel);

            ProductViewModel savedProduct = await _productsApiService.AddProductAsync(product);

            return Ok(savedProduct);
        }

        [HttpPut]
        [Route("product/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> AddOrUpdateProduct([FromRoute] int id, [FromBody] ProductViewModel productViewModel)
        {
            Product product = _mapper.Map<ProductViewModel, Product>(productViewModel);

            ProductViewModel savedProduct = await _productsApiService.AddOrUpdateProductAsync(product);

            return Ok(savedProduct);
        }

        [HttpDelete]
        [Route("product/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            if (id == 0)
                return NoContent();

            bool isDeleted = await _productsApiService.DeleteProductByIdAsync(id);

            return Ok(isDeleted);

        }
    }
}