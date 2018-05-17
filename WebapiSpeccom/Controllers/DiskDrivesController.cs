using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiSpeccom.Models;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/DiskDrives")]
    public class DiskDrivesController : Controller
    {
        private readonly speccomContext _context;

        public DiskDrivesController(speccomContext context)
        {
            _context = context;
        }

        // GET: api/DiskDrives
        [HttpGet]
        public IEnumerable<DiskDrive> GetDiskDrive()
        {
            return _context.DiskDrive;
        }

        // GET: api/DiskDrives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiskDrive([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diskDrive = await _context.DiskDrive.SingleOrDefaultAsync(m => m.DiskDriveId == id);

            if (diskDrive == null)
            {
                return NotFound();
            }

            return Ok(diskDrive);
        }

        // PUT: api/DiskDrives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiskDrive([FromRoute] int id, [FromBody] DiskDrive diskDrive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diskDrive.DiskDriveId)
            {
                return BadRequest();
            }

            _context.Entry(diskDrive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiskDriveExists(id))
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

        // POST: api/DiskDrives
        [HttpPost]
        public async Task<IActionResult> PostDiskDrive([FromBody] DiskDrive diskDrive)
        {
            var comid = _context.Computer.Max(s => s.Cpuid);
            diskDrive.Cpuid = comid;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            _context.DiskDrive.Add(diskDrive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiskDrive", new { id = diskDrive.DiskDriveId }, diskDrive);
        }

        // DELETE: api/DiskDrives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiskDrive([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diskDrive = await _context.DiskDrive.SingleOrDefaultAsync(m => m.DiskDriveId == id);
            if (diskDrive == null)
            {
                return NotFound();
            }

            _context.DiskDrive.Remove(diskDrive);
            await _context.SaveChangesAsync();

            return Ok(diskDrive);
        }

        private bool DiskDriveExists(int id)
        {
            return _context.DiskDrive.Any(e => e.DiskDriveId == id);
        }
    }
}