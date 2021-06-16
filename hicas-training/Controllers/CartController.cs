using hicas_training.Models;
using hicas_training.Services.CartServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartService;
        public CartController(ICartServices cartService) => _cartService = cartService;

        // GET: api/Carts/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetCart(int idUser)
        {
            var result = await _cartService.GetCartByID(idUser);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new { status = true, data = result });
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> PutCart(int idUser, Cart cart)
        {
            bool result = await _cartService.UpdateCartByID(idUser, cart.IdUser, cart.Amount);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(new { status = true });
        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            await _cartService.PostCart(cart);

            return Ok(new { status = true });
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}/{iduser}")]
        [Authorize]
        public async Task<ActionResult> DeleteCart(int idCart, int idUser)
        {
            var result = await _cartService.DeleteCart(idCart, idUser);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(new { status = result });
        }

    }
}
