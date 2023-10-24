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
    public class ProductsController : ControllerBase
    {
        private readonly CIT4DbContext _context;

        public ProductsController(CIT4DbContext context)
        {
            _context = context;
        }

        
        // GET: api/Products?name
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct([FromQuery] string? name)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                return await _context.Product.ToListAsync();
            }

            var products = await _context.Product.ToListAsync();

            var query = products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (query == null || query.Count() == 0)
            {
                return NotFound(new List<Product>());
            }

            return query;
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(product.CategoryId);
            if (category == null)
            {
                return product;
            }
            product.Category = category;
            

            return product;
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var category= await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound(new List<Product>());
            }
            var product = _context.Product.Where(x=> x.CategoryId == id).ToList();

            if (product == null || product.Count()==0)
            {
                return NotFound(new List<Product>());
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'CIT4DbContext.Product'  is null.");
            }
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
