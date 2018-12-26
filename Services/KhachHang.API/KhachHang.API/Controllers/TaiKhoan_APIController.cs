using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KhachHang.API.Models;

namespace KhachHang.API.Controllers
{
    [Route("api/QLKhachHang")]
    [ApiController]
    public class TaiKhoan_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_KHACHHANGContext _context;

        public TaiKhoan_APIController(QL_BANMAYTINH_KHACHHANGContext context)
        {
            _context = context;
        }

        // GET: api/Taikhoans_API
        [HttpGet]
        public IEnumerable<Taikhoan> GetTaikhoan()
        {
            var list_taikhoan = from s in _context.Taikhoan where s.TaiKhoan1 != "admin" select s;
            return list_taikhoan;
        }

        // GET: api/Taikhoans_API/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaikhoan([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taikhoan = await _context.Taikhoan.FindAsync(id);

            if (taikhoan == null)
            {
                return NotFound();
            }

            return Ok(taikhoan);
        }

        // PUT: api/Taikhoans_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaikhoan([FromRoute] string id, [FromBody] Taikhoan taikhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taikhoan.TaiKhoan1)
            {
                return BadRequest();
            }

            _context.Entry(taikhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaikhoanExists(id))
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

        // POST: api/Taikhoans_API
        [HttpPost]
        public async Task<IActionResult> PostTaikhoan([FromBody] Taikhoan taikhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Taikhoan.Add(taikhoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaikhoanExists(taikhoan.TaiKhoan1))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaikhoan", new { id = taikhoan.TaiKhoan1 }, taikhoan);
        }

        // DELETE: api/Taikhoans_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaikhoan([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taikhoan = await _context.Taikhoan.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            _context.Taikhoan.Remove(taikhoan);
            await _context.SaveChangesAsync();

            return Ok(taikhoan);
        }

        private bool TaikhoanExists(string id)
        {
            return _context.Taikhoan.Any(e => e.TaiKhoan1 == id);
        }
    }
}