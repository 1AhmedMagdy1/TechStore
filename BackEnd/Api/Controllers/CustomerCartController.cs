using Api.Helper;
using Core.Interfaces;
using Core.Models;
using Core.Sharing;
using Infrustructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CustomerCartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly TechStoreContext _context;

        public CustomerCartController(ICartRepository cartRepository,TechStoreContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<OperationResult<Cart>>>Get(string id)
        {
        
            var cart = await _cartRepository.GetCartAsync(id);
            if (cart.Success)
                return Ok(cart);

            return NotFound(cart);
        }
        [HttpPost]
        public async Task<ActionResult<OperationResult<Cart>>> AddorUpdate(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                     
            }
            var result = await _cartRepository.Update(cart);
            if (result.Success)
                return Ok(cart);

            return BadRequest(cart);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cartRepository.DeleteCart(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }
    }
}
