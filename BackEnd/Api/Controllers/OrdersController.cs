using Core.DTOS;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository OrderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateOrderDTO orderDTO)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email is null)
                return Unauthorized();
            var result = await OrderRepository.CreateOrderAsync(orderDTO, email);
            if (!result.Success)
            {
                return StatusCode(result.StatusCode ?? 400, result);
            }
            return StatusCode(result.StatusCode ?? 200, result);

        }
        [HttpGet("DeliveryMethods")]
        public async Task<IActionResult> GetDeliveryMethods()
        {
           var name= User.FindFirst(ClaimTypes.Email);

            var result = await OrderRepository.GetDeliveryMethods();
            if (!result.Success)
            {
                return StatusCode(result.StatusCode ??400, result);
            }
            return Ok(result);
        }
        
    
    }
}
