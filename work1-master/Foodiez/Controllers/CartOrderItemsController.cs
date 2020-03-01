using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodiez.Models;

namespace Foodiez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartOrderItemsController : ControllerBase
    {
        private readonly FoodiezContext _context;

        public CartOrderItemsController(FoodiezContext context)
        {
            _context = context;
        }

        // GET: api/CartOrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartOrderItem>>> GetCartOrderItem()
        {
            return await _context.CartOrderItem.ToListAsync();
        }

        // GET: api/CartOrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartOrderItem>> GetCartOrderItem(string id)
        {
            var cartOrderItem = await _context.CartOrderItem.FindAsync(id);

            if (cartOrderItem == null)
            {
                return NotFound();
            }

            return cartOrderItem;
        }

        // PUT: api/CartOrderItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartOrderItem(string id, CartOrderItem cartOrderItem)
        {
            if (id != cartOrderItem.CartOrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(cartOrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartOrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartOrderItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CartOrderItem>> PostCartOrderItem(CartOrderItem cartOrderItem)
        {
            _context.CartOrderItem.Add(cartOrderItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartOrderItemExists(cartOrderItem.CartOrderItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCartOrderItem", new { id = cartOrderItem.CartOrderItemId }, cartOrderItem);
        }

        // DELETE: api/CartOrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartOrderItem>> DeleteCartOrderItem(string id)
        {
            var cartOrderItem = await _context.CartOrderItem.FindAsync(id);
            if (cartOrderItem == null)
            {
                return NotFound();
            }

            _context.CartOrderItem.Remove(cartOrderItem);
            await _context.SaveChangesAsync();

            return cartOrderItem;
        }

        private bool CartOrderItemExists(string id)
        {
            return _context.CartOrderItem.Any(e => e.CartOrderItemId == id);
        }
    }
}
