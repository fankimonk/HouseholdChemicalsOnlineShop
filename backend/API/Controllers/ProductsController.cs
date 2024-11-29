using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using API.Contracts.Product;

namespace API.Controllers
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
        //[Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productsRepo.GetAllAsync();
            var productsResponse = products.Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.ImagePath, p.Price, p.StockQuantity, p.CategoryId, p.BrandId));
            return Ok(productsResponse);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productsRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            var productResponse = new ProductResponse(
                product.Id, product.Name, product.Description, product.ImagePath, 
                product.Price, product.StockQuantity, product.CategoryId, product.BrandId);
            return Ok(productResponse);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest productRequest)
        {
            var product = await _productsRepo.CreateAsync(new Product { 
                Name = productRequest.Name,
                Description = productRequest.Description,
                ImagePath = productRequest.ImagePath,
                Price = productRequest.Price,
                StockQuantity = productRequest.StockQuantity,
                CategoryId = productRequest.CategoryId,
                BrandId = productRequest.BrandId
                });
            if (product == null) return BadRequest(nameof(product));
            return CreatedAtAction(nameof(Create), new ProductResponse(
                product.Id, product.Name, product.Description, product.ImagePath, 
                product.Price, product.StockQuantity, product.CategoryId, product.BrandId));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequest productRequest)
        {
            var product = await _productsRepo.UpdateAsync(id, new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                ImagePath = productRequest.ImagePath,
                Price = productRequest.Price,
                StockQuantity = productRequest.StockQuantity,
                CategoryId = productRequest.CategoryId,
                BrandId = productRequest.BrandId
            });
            if (product == null) return BadRequest(nameof(product));
            return Ok(new ProductResponse(
                product.Id, product.Name, product.Description, product.ImagePath,
                product.Price, product.StockQuantity, product.CategoryId, product.BrandId));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productsRepo.DeleteAsync(id);
            return NoContent();
        }

    }
}
