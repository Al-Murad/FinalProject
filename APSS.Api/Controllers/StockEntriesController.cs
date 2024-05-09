using APSS.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APSS.Api.Controllers
{
    public class StockEntriesController : Controller
    {
    
        private readonly AutoPartsDbContext _context;
        public StockEntriesController(AutoPartsDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockEntry>>> GetStockEntries()
        {
            return await _context.StockEntries.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StockEntry>> GetStockEntry(int id)
        {
            var StockEntry = await _context.StockEntries.FirstOrDefaultAsync(c => c.StockEntryId == id);
            if (StockEntry == null) { return NotFound(); }
            return Ok(StockEntry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockEntry(int id, StockEntry StockEntry)
        {
            if (id != StockEntry.StockEntryId)
            {
                return BadRequest();
            }

            _context.Entry(StockEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<StockEntry>> PostStockEntry(StockEntry StockEntry)
        {
            _context.StockEntries.Add(StockEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockEntry", new { id = StockEntry.StockEntryId }, StockEntry);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockEntry(int id)
        {
            var StockEntry = await _context.StockEntries.FindAsync(id);
            if (StockEntry == null)
            {
                return NotFound();
            }

            _context.StockEntries.Remove(StockEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
