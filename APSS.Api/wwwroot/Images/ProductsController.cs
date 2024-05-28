using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R59_M10_Class13_Work_02.Models;
using R59_M10_Class13_Work_02.ViewModels;

namespace R59_M10_Class13_Work_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IWebHostEnvironment env;
        public ProductsController(ProductDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpGet("Sales/Include")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductWithSales()
        {
            return await _context.Products
                .Include(x => x.Sales)
                .Include(x=> x.SellUnit)
                .ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Product>> GetProductWithSales(int id)
        {
            var product = await _context.Products
                .Include(x => x.Sales)
                .Include(x=> x.SellUnit)
                .FirstOrDefaultAsync(x=> x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        //
        // Custom
        // Sales data of 
        //===========================================
        [HttpGet("Sales/Of/{id}")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesOfProduct(int id)
        {
            var data = await _context.Sales.Where(x=> x.ProductId ==id).ToListAsync();
            return data;
        }
        //===========================================
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
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

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("Upload/{id}")]
        public async Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null) return NotFound();
            string ext = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
            string savePath = Path.Combine(this.env.WebRootPath, "Pictures", fileName);
            if (!Directory.Exists(Path.Combine(this.env.WebRootPath, "Pictures")))
            {
                Directory.CreateDirectory(Path.Combine(this.env.WebRootPath, "Pictures"));
            }
            FileStream fs = new FileStream(savePath, FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            product.Picture = fileName;
            await _context.SaveChangesAsync();
            return new UploadResponse { FileName = fileName };

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
