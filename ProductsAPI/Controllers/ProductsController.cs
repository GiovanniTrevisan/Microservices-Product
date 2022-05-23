using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Products.API.ViewModels;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [OpenApiTag("Products", Description = "Product Management")]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet(Name = "GetProducts")]
        [Route("product/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> GetProduct([FromRoute] int id)
        {
            if (id == 0)
                return NoContent();

            ProductViewModel response = await _carteiraContratoApiService.GetContratoByNumContratoAsync(numContrato);

            return Ok(response);

        }

        [HttpGet(Name = "GetProducts")]
        [Route("product")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(ProductViewModel))]
        public async Task<ActionResult> GetProducts()
        {
            List<ProductViewModel> response = await _carteiraContratoApiService.GetContratoByNumContratoAsync(numContrato);

            return Ok(response);
        }
    }
}