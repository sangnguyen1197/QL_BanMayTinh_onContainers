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
    [Route("api/ChiTietPhieuNhap")]
    [ApiController]
    public class Chitietphieunhap_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_PHIEUNHAPContext _context;

        public Chitietphieunhap_APIController(QL_BANMAYTINH_PHIEUNHAPContext context)
        {
            _context = context;
        }

        // GET: api/Chitietphieunhap_API
        [HttpGet]
        public IEnumerable<Chitietphieunhap> GetChitietphieunhap()
        {
            return _context.Chitietphieunhap;
        }

        // GET: api/Chitietphieunhap_API/5
        [HttpGet("{mapn}/{masp}")]
        public async Task<IActionResult> GetChitietphieunhap([FromRoute] string mapn, [FromRoute] string masp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitietphieunhap = await _context.Chitietphieunhap.FindAsync(mapn, masp);

            if (chitietphieunhap == null)
            {
                return NotFound();
            }

            return Ok(chitietphieunhap);
        }

        // PUT: api/Chitietphieunhap_API/5
        [HttpPut("{mapn}/{masp}")]
        public async Task<IActionResult> PutChitietphieunhap([FromRoute] string mapn, [FromRoute] string masp, [FromBody] Chitietphieunhap chitietphieunhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mapn != chitietphieunhap.MaPn || masp != chitietphieunhap.MaSp)
            {
                return BadRequest();
            }

            _context.Entry(chitietphieunhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitietphieunhapExists(mapn) || !ChitietphieunhapExists(masp))
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

        // POST: api/Chitietphieunhap_API
        [HttpPost]
        public async Task<IActionResult> PostChitietphieunhap([FromBody] Chitietphieunhap chitietphieunhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Chitietphieunhap.Add(chitietphieunhap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChitietphieunhapExists(chitietphieunhap.MaPn))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChitietphieunhap", new { id = chitietphieunhap.MaPn }, chitietphieunhap);
        }

        // DELETE: api/Chitietphieunhap_API/5
        [HttpDelete("{mapn}/{masp}")]
        public async Task<IActionResult> DeleteChitietphieunhap([FromRoute] string mapn, [FromRoute] string masp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitietphieunhap = await _context.Chitietphieunhap.FindAsync(mapn, masp);
            if (chitietphieunhap == null)
            {
                return NotFound();
            }

            _context.Chitietphieunhap.Remove(chitietphieunhap);
            await _context.SaveChangesAsync();

            return Ok(chitietphieunhap);
        }

        private bool ChitietphieunhapExists(string id)
        {
            return _context.Chitietphieunhap.Any(e => e.MaPn == id);
        }
    }
}