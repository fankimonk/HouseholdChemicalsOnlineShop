using API.Contracts.Product;
using Application.Authorization;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/carts")]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cartService;

        public CartsController(ICartsService cartsService)
        {
            _cartService = cartsService;
        }

        [HttpPost("{productId}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> AddProduct([FromRoute] int productId)
        {
            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId)!.Value);
            var product = await _cartService.AddProduct(userId, productId);
            if (product == null) return BadRequest();
            return Ok();
        }

        [HttpGet("getproducts")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetProducts()
        {
            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId)!.Value);
            var products = await _cartService.GetProducts(userId);
            var productsReponse = products.Select(p => new ProductResponse(
                p.Id, 
                p.Name, 
                p.Description, 
                p.ImagePath,
                p.Price,
                p.StockQuantity,
                p.CategoryId,
                p.BrandId));
            return Ok(productsReponse);
        }

        [HttpDelete("{productId}")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId)!.Value);
            await _cartService.DeleteProduct(userId, productId);
            return NoContent();
        }
    }
}
