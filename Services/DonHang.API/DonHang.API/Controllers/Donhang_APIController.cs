using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonHang.API.Models;

namespace DonHang.API.Controllers
{
    [Route("api/QLDonHang")]
    [ApiController]
    public class Donhang_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_DONHANGContext _context;

        public Donhang_APIController(QL_BANMAYTINH_DONHANGContext context)
        {
            _context = context;
        }

        // GET: api/Donhang_API
        [HttpGet]
        public IEnumerable<Donhang> GetDonhang()
        {
            return _context.Donhang;
        }

        // GET: api/Donhang_API/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonhang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donhang = await _context.Donhang.FindAsync(id);

            if (donhang == null)
            {
                return NotFound();
            }

            return Ok(donhang);
        }

        // PUT: api/Donhang_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonhang([FromRoute] string id, [FromBody] Donhang donhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donhang.MaDh)
            {
                return BadRequest();
            }

            _context.Entry(donhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonhangExists(id))
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

        // POST: api/Donhang_API
        [HttpPost]
        public async Task<IActionResult> PostDonhang([FromBody] Donhang donhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Donhang.Add(donhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonhangExists(donhang.MaDh))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonhang", new { id = donhang.MaDh }, donhang);
        }

        // DELETE: api/Donhang_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonhang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donhang = await _context.Donhang.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }

            _context.Donhang.Remove(donhang);
            await _context.SaveChangesAsync();

            return Ok(donhang);
        }

        private bool DonhangExists(string id)
        {
            return _context.Donhang.Any(e => e.MaDh == id);
        }
    }
}