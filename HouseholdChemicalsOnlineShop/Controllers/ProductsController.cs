using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Mappers;
using DataAccess.Models.DTOs.Product;

namespace HouseholdChemicalsOnlineShop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;

        public ProductsController(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productsRepo.GetAllAsync();
            var productDTOs = products.Select(p => p.ToDefaultDTO());
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productsRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            var productDTO = product.ToDefaultDTO();
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO productDTO)
        {
            var product = await _productsRepo.CreateAsync(productDTO.ToProduct());
            if (product == null) return BadRequest(nameof(product));
            return CreatedAtAction(nameof(Create), product.ToDefaultDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDTO productDTO)
        {
            var product = await _productsRepo.UpdateAsync(id, productDTO.ToProduct());
            if (product == null) return BadRequest(nameof(product));
            return Ok(product.ToDefaultDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productsRepo.DeleteAsync(id);
            return NoContent();
        }

    }
}
