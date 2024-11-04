using API.Contracts.Category;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoriesRepo.GetAllAsync();
            var categoriesResponse = categories.Select(c => new CategoryResponse(c.Id, c.Name));
            return Ok(categoriesResponse);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoriesRepo.GetByIdAsync(id);
            if (category == null) return NotFound();
            var categoryResponse = new CategoryResponse(category.Id, category.Name);
            return Ok(categoryResponse);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest categoryRequest)
        {
            var category = await _categoriesRepo.CreateAsync(new Category { Name = categoryRequest.Name });
            if (category == null) return BadRequest(nameof(category));
            return CreatedAtAction(nameof(Create), new CategoryResponse(category.Id, category.Name));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest categoryRequest)
        {
            var category = await _categoriesRepo.UpdateAsync(id, new Category { Name = categoryRequest.Name });
            if (category == null) return BadRequest(nameof(category));
            return Ok(new CategoryResponse(category.Id, category.Name));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _categoriesRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
