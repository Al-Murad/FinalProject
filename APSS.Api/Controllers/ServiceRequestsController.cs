﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using APSS.Lib.Models;
=======
<<<<<<< HEAD
using APSS.Lib.Models;
=======
using APSS.Api.Models;
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a

namespace APSS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly AutoPartsDbContext _context;

        public ServiceRequestsController(AutoPartsDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        // GET: api/ServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);

            if (serviceRequest == null)
            {
                return NotFound();
            }

            return serviceRequest;
        }

        // PUT: api/ServiceRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRequest(int id, ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.ServiceRequestId)
            {
                return BadRequest();
            }

            _context.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(id))
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

        // POST: api/ServiceRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceRequest", new { id = serviceRequest.ServiceRequestId }, serviceRequest);
        }

        // DELETE: api/ServiceRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequests.Any(e => e.ServiceRequestId == id);
        }
    }
}
