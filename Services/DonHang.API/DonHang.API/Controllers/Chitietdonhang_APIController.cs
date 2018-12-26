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
    [Route("api/ChiTietDonHang")]
    [ApiController]
    public class Chitietdonhang_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_DONHANGContext _context;

        public Chitietdonhang_APIController(QL_BANMAYTINH_DONHANGContext context)
        {
            _context = context;
        }

        // GET: api/Chitietdonhang_API
        [HttpGet]
        public IEnumerable<Chitietdonhang> GetChitietdonhang()
        {
            return _context.Chitietdonhang;
        }

        // GET: api/Chitietdonhang_API/5
        [HttpGet("{madh}/{masp}")]
        public async Task<IActionResult> GetChitietdonhang([FromRoute] string madh, [FromRoute] string masp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitietdonhang = await _context.Chitietdonhang.FindAsync(madh, masp);

            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return Ok(chitietdonhang);
        }

        // PUT: api/Chitietdonhang_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChitietdonhang([FromRoute] string id, [FromBody] Chitietdonhang chitietdonhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chitietdonhang.MaDh)
            {
                return BadRequest();
            }

            _context.Entry(chitietdonhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitietdonhangExists(id))
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

        // POST: api/Chitietdonhang_API
        [HttpPost]
        public async Task<IActionResult> PostChitietdonhang([FromBody] Chitietdonhang chitietdonhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Chitietdonhang.Add(chitietdonhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChitietdonhangExists(chitietdonhang.MaDh))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChitietdonhang", new { id = chitietdonhang.MaDh }, chitietdonhang);
        }

        // DELETE: api/Chitietdonhang_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChitietdonhang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitietdonhang = await _context.Chitietdonhang.FindAsync(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            _context.Chitietdonhang.Remove(chitietdonhang);
            await _context.SaveChangesAsync();

            return Ok(chitietdonhang);
        }

        private bool ChitietdonhangExists(string id)
        {
            return _context.Chitietdonhang.Any(e => e.MaDh == id);
        }
    }
}