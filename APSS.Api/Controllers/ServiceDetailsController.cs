using APSS.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APSS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailsController : ControllerBase
    {
        private readonly AutoPartsDbContext _context;
        public ServiceDetailsController(AutoPartsDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDetail>>> GetServiceDetails()
        {
            return await _context.ServiceDetails.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDetail>> GetServiceDetail(int id)
        {
            var serviceDetail = await _context.ServiceDetails.FirstOrDefaultAsync(c => c.ServiceDetailId == id);
            if (serviceDetail == null) { return NotFound(); }
            return Ok(serviceDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceDetail(int id, ServiceDetail serviceDetail)
        {
            if (id != serviceDetail.ServiceDetailId)
            {
                return BadRequest();
            }

            _context.Entry(serviceDetail).State = EntityState.Modified;

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
        public async Task<ActionResult<ServiceDetail>> PostServiceDetail(ServiceDetail serviceDetail)
        {
            _context.ServiceDetails.Add(serviceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceDetail", new { id = serviceDetail.ServiceDetailId }, serviceDetail);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceDetail(int id)
        {
            var ServiceDetail = await _context.ServiceDetails.FindAsync(id);
            if (ServiceDetail == null)
            {
                return NotFound();
            }

            _context.ServiceDetails.Remove(ServiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
