using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhieuNhap.API.Models;

namespace PhieuNhap.API.Controllers
{
    [Route("api/QLPhieuNhap")]
    [ApiController]
    public class Phieunhap_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_PHIEUNHAPContext _context;

        public Phieunhap_APIController(QL_BANMAYTINH_PHIEUNHAPContext context)
        {
            _context = context;
        }

        // GET: api/Phieunhap_API
        [HttpGet]
        public IEnumerable<Phieunhap> GetPhieunhap()
        {
            return _context.Phieunhap;
        }

        // GET: api/Phieunhap_API/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhieunhap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phieunhap = await _context.Phieunhap.FindAsync(id);

            if (phieunhap == null)
            {
                return NotFound();
            }

            return Ok(phieunhap);
        }

        // PUT: api/Phieunhap_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieunhap([FromRoute] string id, [FromBody] Phieunhap phieunhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieunhap.MaPn)
            {
                return BadRequest();
            }

            _context.Entry(phieunhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieunhapExists(id))
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

        // POST: api/Phieunhap_API
        [HttpPost]
        public async Task<IActionResult> PostPhieunhap([FromBody] Phieunhap phieunhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Phieunhap.Add(phieunhap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhieunhapExists(phieunhap.MaPn))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhieunhap", new { id = phieunhap.MaPn }, phieunhap);
        }

        // DELETE: api/Phieunhap_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieunhap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phieunhap = await _context.Phieunhap.FindAsync(id);
            if (phieunhap == null)
            {
                return NotFound();
            }

            _context.Phieunhap.Remove(phieunhap);
            await _context.SaveChangesAsync();

            return Ok(phieunhap);
        }

        private bool PhieunhapExists(string id)
        {
            return _context.Phieunhap.Any(e => e.MaPn == id);
        }
    }
}