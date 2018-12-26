using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanPham.API.Models;

namespace SanPham.API.Controllers
{
    [Route("api/QLThuongHieu")]
    [ApiController]
    public class Thuonghieu_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_SANPHAMContext _context;

        public Thuonghieu_APIController(QL_BANMAYTINH_SANPHAMContext context)
        {
            _context = context;
        }

        // GET: api/Thuonghieu_API
        [HttpGet]
        public IEnumerable<Thuonghieu> GetThuonghieu()
        {
            return _context.Thuonghieu;
        }

        // GET: api/Thuonghieu_API/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThuonghieu([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thuonghieu = await _context.Thuonghieu.FindAsync(id);

            if (thuonghieu == null)
            {
                return NotFound();
            }

            return Ok(thuonghieu);
        }

        // PUT: api/Thuonghieu_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuonghieu([FromRoute] string id, [FromBody] Thuonghieu thuonghieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thuonghieu.MaThuongHieu)
            {
                return BadRequest();
            }

            _context.Entry(thuonghieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuonghieuExists(id))
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

        // POST: api/Thuonghieu_API
        [HttpPost]
        public async Task<IActionResult> PostThuonghieu([FromBody] Thuonghieu thuonghieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Thuonghieu.Add(thuonghieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThuonghieuExists(thuonghieu.MaThuongHieu))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThuonghieu", new { id = thuonghieu.MaThuongHieu }, thuonghieu);
        }

        // DELETE: api/Thuonghieu_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuonghieu([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            _context.Thuonghieu.Remove(thuonghieu);
            await _context.SaveChangesAsync();

            return Ok(thuonghieu);
        }

        private bool ThuonghieuExists(string id)
        {
            return _context.Thuonghieu.Any(e => e.MaThuongHieu == id);
        }
    }
}