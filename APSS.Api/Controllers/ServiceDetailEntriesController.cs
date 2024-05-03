using APSS.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APSS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailEntriesController : ControllerBase
    {
        private readonly AutoPartsDbContext _context;
        public ServiceDetailEntriesController(AutoPartsDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDetailEntry>>> GetServiceDetailEntries()
        {
            return await _context.ServiceDetailEntries.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDetailEntry>> GetServiceDetailEntry(int id)
        {
            var serviceDetailEntry = await _context.ServiceDetailEntries.FirstOrDefaultAsync(c => c.ServiceDetailEntryId == id);
            if (serviceDetailEntry == null) { return NotFound(); }
            return Ok(serviceDetailEntry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceDetailEntry(int id, ServiceDetailEntry serviceDetailEntry)
        {
            if (id != serviceDetailEntry.ServiceDetailEntryId)
            {
                return BadRequest();
            }

            _context.Entry(serviceDetailEntry).State = EntityState.Modified;

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
        public async Task<ActionResult<ServiceDetailEntry>> PostServiceDetailEntry(ServiceDetailEntry serviceDetailEntry)
        {
            _context.ServiceDetailEntries.Add(serviceDetailEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceDetailEntry", new { id = serviceDetailEntry.ServiceDetailEntryId }, serviceDetailEntry);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceDetailEntry(int id)
        {
            var serviceDetailEntry = await _context.ServiceDetailEntries.FindAsync(id);
            if (serviceDetailEntry == null)
            {
                return NotFound();
            }

            _context.ServiceDetailEntries.Remove(serviceDetailEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
