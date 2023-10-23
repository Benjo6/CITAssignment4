using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CITAssignment4.DataLayer.Domain;

namespace CITAssignment4.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly CIT4DbContext _context;

        public OrderDetailsController(CIT4DbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
          if (_context.OrderDetails == null)
          {
              return NotFound();
          }
            return await _context.OrderDetails.ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int id)
        {
          if (_context.OrderDetails == null)
          {
              return NotFound();
          }
            var orderDetails = await _context.OrderDetails.FindAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return orderDetails;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetails(int id, OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
          if (_context.OrderDetails == null)
          {
              return Problem("Entity set 'CIT4DbContext.OrderDetails'  is null.");
          }
            _context.OrderDetails.Add(orderDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderDetailsExists(orderDetails.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderDetails", new { id = orderDetails.OrderId }, orderDetails);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool OrderDetailsExists(int id)
        {
            return (_context.OrderDetails?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
