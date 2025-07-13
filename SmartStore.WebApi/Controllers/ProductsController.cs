using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Models.Dtos.Products.Requests;
using SmartStore.Services.Abstracts;

namespace SmartStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : ControllerBase
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllProducts(bool enableTracking = false, bool withDeleted = false, CancellationToken cancellationToken = default)
        {
            var result = await _productService.GetAllAsync(enableTracking, withDeleted, cancellationToken: cancellationToken);
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var result = await _productService.GetByIdAsync(id);
           
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest productDto)
        {
            var result = await _productService.AddAsync(productDto);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct( [FromBody] UpdateProductRequest productDto)
        {
            var result = await _productService.UpdateAsync(productDto);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var result = await _productService.RemoveAsync(id);
            return Ok(result);
        }

    }
}
