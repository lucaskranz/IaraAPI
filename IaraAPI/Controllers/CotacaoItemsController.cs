using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IaraAPI.Data;
using IaraAPI.Models;

namespace IaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoItemsController : ControllerBase
    {
        private readonly IaraAPIContext _context;

        public CotacaoItemsController(IaraAPIContext context)
        {
            _context = context;
        }

        // GET: api/CotacaoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CotacaoItem>>> GetCotacaoItem()
        {
            return await _context.CotacaoItem.ToListAsync();
        }

        // GET: api/CotacaoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CotacaoItem>> GetCotacaoItem(int id)
        {
            var cotacaoItem = await _context.CotacaoItem.FindAsync(id);

            if (cotacaoItem == null)
            {
                return NotFound();
            }

            return cotacaoItem;
        }

        // PUT: api/CotacaoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotacaoItem(int id, CotacaoItem cotacaoItem)
        {
            if (id != cotacaoItem.CotacaoItemId)
            {
                return BadRequest();
            }

            _context.Entry(cotacaoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotacaoItemExists(id))
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

        // POST: api/CotacaoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CotacaoItem>> PostCotacaoItem(CotacaoItem cotacaoItem)
        {
            _context.CotacaoItem.Add(cotacaoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotacaoItem", new { id = cotacaoItem.CotacaoItemId }, cotacaoItem);
        }

        // DELETE: api/CotacaoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotacaoItem(int id)
        {
            var cotacaoItem = await _context.CotacaoItem.FindAsync(id);
            if (cotacaoItem == null)
            {
                return NotFound();
            }

            _context.CotacaoItem.Remove(cotacaoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CotacaoItemExists(int id)
        {
            return _context.CotacaoItem.Any(e => e.CotacaoItemId == id);
        }
    }
}
