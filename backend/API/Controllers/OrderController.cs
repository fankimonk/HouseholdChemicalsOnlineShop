using API.Contracts.Order;
using API.Contracts.Product;
using API.Mappers;
using Application.Authorization;
using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrdersService _ordersService;
        private readonly IOrderProductsRepository _orderProductsRepository;

        public OrderController(IOrdersRepository ordersRepository, IOrdersService ordersService, IOrderProductsRepository orderProductsRepository)
        {
            _ordersRepository = ordersRepository;
            _ordersService = ordersService;
            _orderProductsRepository = orderProductsRepository;
        }

        [HttpGet("getorders")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> GetOrders()
        {
            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId)!.Value);
            var orders = await _ordersRepository.GetByUserIdAsync(userId);
            if (orders == null) return NotFound();

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId)!.Value);

            var order = await _ordersService.CreateOrder(userId, request.ShippingAddress, request.ProductIds);
            if (order == null) return BadRequest();

            return Ok();
        }
    }
}
