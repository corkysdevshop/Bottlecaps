using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bottlecaps.Models;

namespace Bottlecaps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly BottlecapsContext _context;

        public LinksController(BottlecapsContext context)
        {
            _context = context;
        }

        // GET: api/Links
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLink()
        {
            return await _context.Link.ToListAsync();
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLink(int id)
        {
            //var link = await _context.Link.FindAsync(id);
            var links = await _context.Link.Where(bc => bc.BottlecapId == id)
                .ToListAsync();

            if (links == null)
            {
                return NotFound();
            }

            return links;
        }

        // PUT: api/Links/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLink(int id, Link link)
        {
            if (id != link.LinkId)
            {
                return BadRequest();
            }

            _context.Entry(link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
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

        // POST: api/Links
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Link>> PostLink(Link link)
        {
            _context.Link.Add(link);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LinkExists(link.LinkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLink", new { id = link.LinkId }, link);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Link>> DeleteLink(int id)
        {
            var link = await _context.Link.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            _context.Link.Remove(link);
            await _context.SaveChangesAsync();

            return link;
        }

        private bool LinkExists(int id)
        {
            return _context.Link.Any(e => e.LinkId == id);
        }
    }
}
