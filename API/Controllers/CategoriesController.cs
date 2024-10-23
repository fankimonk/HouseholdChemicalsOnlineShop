using DataAccess.DTOs.Category;
using DataAccess.Interfaces;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepo;

        public CategoriesController(ICategoriesRepository categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoriesRepo.GetAllAsync();
            var categoryDTOs = categories.Select(c => c.ToDTO());
            return Ok(categoryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoriesRepo.GetByIdAsync(id);
            if (category == null) return NotFound();
            var categoryDTO = category.ToDTO();
            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest categoryDTO)
        {
            var category = await _categoriesRepo.CreateAsync(categoryDTO.ToCategory());
            if (category == null) return BadRequest(nameof(category));
            return CreatedAtAction(nameof(Create), category.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest categoryDTO)
        {
            var category = await _categoriesRepo.UpdateAsync(id, categoryDTO.ToCategory());
            if (category == null) return BadRequest(nameof(category));
            return Ok(category.ToDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _categoriesRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
