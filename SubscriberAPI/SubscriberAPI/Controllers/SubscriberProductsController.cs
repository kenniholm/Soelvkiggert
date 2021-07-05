using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriberAPI.Models;

namespace SubscriberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberProductsController : ControllerBase
    {
        private readonly SubscriberAPIContext _context;

        public SubscriberProductsController(SubscriberAPIContext context)
        {
            _context = context;
        }

        // GET: api/SubscriberProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriberProduct>>> GetSubscriberProduct()
        {
            return await _context.SubscriberProduct.ToListAsync();
        }

        // GET: api/SubscriberProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriberProduct>> GetSubscriberProduct(int id)
        {
            var subscriberProduct = await _context.SubscriberProduct.FindAsync(id);

            if (subscriberProduct == null)
            {
                return NotFound();
            }

            return subscriberProduct;
        }

        // PUT: api/SubscriberProducts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriberProduct(int id, SubscriberProduct subscriberProduct)
        {
            if (id != subscriberProduct.ID)
            {
                return BadRequest();
            }

            _context.Entry(subscriberProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberProductExists(id))
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

        // POST: api/SubscriberProducts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SubscriberProduct>> PostSubscriberProduct(SubscriberProduct subscriberProduct)
        {
            _context.SubscriberProduct.Add(subscriberProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriberProduct", new { id = subscriberProduct.ID }, subscriberProduct);
        }

        // DELETE: api/SubscriberProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubscriberProduct>> DeleteSubscriberProduct(int id)
        {
            var subscriberProduct = await _context.SubscriberProduct.FindAsync(id);
            if (subscriberProduct == null)
            {
                return NotFound();
            }

            _context.SubscriberProduct.Remove(subscriberProduct);
            await _context.SaveChangesAsync();

            return subscriberProduct;
        }

        private bool SubscriberProductExists(int id)
        {
            return _context.SubscriberProduct.Any(e => e.ID == id);
        }
    }
}
