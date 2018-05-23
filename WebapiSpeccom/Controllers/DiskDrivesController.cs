using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpeccomDB.Models;
using SpeccomInterface;

namespace WebapiSpeccom.Controllers
{
    [Produces("application/json")]
    [Route("api/DiskDrives")]
    public class DiskDrivesController : Controller
    {
        private readonly IDiskDrive idiskDrive;

        public DiskDrivesController(IDiskDrive context)
        {
            idiskDrive = context;
        }

        // GET: api/DiskDrives
        [HttpGet]
        public IEnumerable<DiskDrive> GetDiskDrive()
        {
            return idiskDrive.GetAllDiskDrive();
        }

        // GET: api/DiskDrives/5
        [HttpGet("{id}")]
        public IActionResult GetDiskDrive([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diskDrive = idiskDrive.GetDiskDriveByID(id);

            if (diskDrive == null)
            {
                return NotFound();
            }

            return Ok(diskDrive);
        }

        // PUT: api/DiskDrives/5
        [HttpPut("{id}")]
        public IActionResult PutDiskDrive([FromRoute] int id, [FromBody] DiskDrive diskDrive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diskDrive.DiskDriveId)
            {
                return BadRequest();
            }

            idiskDrive.PutDiskDrive(id, diskDrive);


            return NoContent();
        }

        // POST: api/DiskDrives
        [HttpPost]
        public IActionResult PostDiskDrive([FromBody] DiskDrive diskDrive)
        {

            idiskDrive.AddDiskDrive(diskDrive);


            return CreatedAtAction("GetDiskDrive", new { id = diskDrive.DiskDriveId }, diskDrive);
        }

        // DELETE: api/DiskDrives/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDiskDrive([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var diskDrive = await _context.DiskDrive.SingleOrDefaultAsync(m => m.DiskDriveId == id);
        //    if (diskDrive == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DiskDrive.Remove(diskDrive);
        //    await _context.SaveChangesAsync();

        //    return Ok(diskDrive);
        //}

        //private bool DiskDriveExists(int id)
        //{
        //    return _context.DiskDrive.Any(e => e.DiskDriveId == id);
        //}
    }
}