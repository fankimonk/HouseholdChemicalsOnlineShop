using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using API.Contracts.Product;
using DataAccess.Queries;
using Application.Interfaces;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductsService _productsService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductsRepository productsRepo, IProductsService productsService, IWebHostEnvironment webHostEnvironment)
        {
            _productsRepository = productsRepo;
            _productsService = productsService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductsQuery query)
        {
            var products = await _productsRepository.GetAllAsync(query);
            var productsResponse = products.Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.ImagePath, p.Price, p.StockQuantity, p.CategoryId, p.BrandId));
            return Ok(productsResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            var productResponse = new ProductResponse(
                product.Id, product.Name, product.Description, product.ImagePath, 
                product.Price, product.StockQuantity, product.CategoryId, product.BrandId);
            return Ok(productResponse);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest productRequest)
        {
            if (!ModelState.IsValid) return BadRequest("ывмыв");

            var webRootPath = _webHostEnvironment.WebRootPath;

            var product = await _productsService.CreateProduct(productRequest.Name, productRequest.Description, productRequest.Image, 
                productRequest.Price, productRequest.StockQuantity, productRequest.CategoryId, productRequest.BrandId, webRootPath);

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateProductRequest productRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = await _productsRepository.UpdateAsync(id, new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
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
            await _productsRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
