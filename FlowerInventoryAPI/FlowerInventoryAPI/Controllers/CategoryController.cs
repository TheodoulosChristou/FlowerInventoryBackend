using FlowerInventoryAPI.Entities;
using FlowerInventoryAPI.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var result = await _service.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("GetCategoryByCategoryId")]
        public async Task<ActionResult<Category>> GetCategoryByCategoryId(int categoryId)
        {
            var result = await _service.GetCategoryByCategoryId(categoryId);
            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category categoryRequest)
        {
            var result = await _service.CreateCategory(categoryRequest);
            return Ok(result);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category categoryRequest)
        {
            var result = await _service.UpdateCategory(categoryRequest);
            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteCategory([FromBody] Category categoryRequest)
        {
            var result = await _service.DeleteCategory(categoryRequest);
            return Ok(result);
        }
    }
}
