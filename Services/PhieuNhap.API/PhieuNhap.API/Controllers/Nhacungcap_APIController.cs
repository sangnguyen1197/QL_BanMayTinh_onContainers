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
    [Route("api/QLNhaCungCap")]
    [ApiController]
    public class Nhacungcap_APIController : ControllerBase
    {
        private readonly QL_BANMAYTINH_PHIEUNHAPContext _context;

        public Nhacungcap_APIController(QL_BANMAYTINH_PHIEUNHAPContext context)
        {
            _context = context;
        }

        // GET: api/Nhacungcap_API
        [HttpGet]
        public IEnumerable<Nhacungcap> GetNhacungcap()
        {
            return _context.Nhacungcap;
        }

        // GET: api/Nhacungcap_API/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhacungcap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);

            if (nhacungcap == null)
            {
                return NotFound();
            }

            return Ok(nhacungcap);
        }

        // PUT: api/Nhacungcap_API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhacungcap([FromRoute] string id, [FromBody] Nhacungcap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhacungcap.MaNcc)
            {
                return BadRequest();
            }

            _context.Entry(nhacungcap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhacungcapExists(id))
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

        // POST: api/Nhacungcap_API
        [HttpPost]
        public async Task<IActionResult> PostNhacungcap([FromBody] Nhacungcap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Nhacungcap.Add(nhacungcap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhacungcapExists(nhacungcap.MaNcc))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhacungcap", new { id = nhacungcap.MaNcc }, nhacungcap);
        }

        // DELETE: api/Nhacungcap_API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhacungcap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            _context.Nhacungcap.Remove(nhacungcap);
            await _context.SaveChangesAsync();

            return Ok(nhacungcap);
        }

        private bool NhacungcapExists(string id)
        {
            return _context.Nhacungcap.Any(e => e.MaNcc == id);
        }
    }
}