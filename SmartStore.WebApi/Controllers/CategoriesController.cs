using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Models.Dtos.Categories.Requests;
using SmartStore.Services.Abstracts;

namespace SmartStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategoryRequest request)
        {
            var result = await _categoryService.AddAsync(request);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync(bool enableTracking = false, bool withDeleted = false, CancellationToken cancellationToken = default)
        {
            var result = await _categoryService.GetAllAsync(enableTracking, withDeleted, cancellationToken: cancellationToken);
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
          
            return Ok(result);

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync( [FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateAsync(request);
           
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.RemoveAsync(id);
           
            return Ok(result);
        }


    }
}
