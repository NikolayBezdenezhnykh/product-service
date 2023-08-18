using Application.Dtos;
using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace product_service.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Product([FromQuery] PaginationParams paginationParams)
        {
            var result = await _productService.GetProductsAsync(paginationParams);
            return Ok(new { Data = result.Item1, Pagination = result.Item2 });
        }

        [HttpGet("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Product([FromQuery] long[] ids)
        {
            var products = await _productService.GetProductsAsync(ids);
            return Ok(products);
        }
    }
}