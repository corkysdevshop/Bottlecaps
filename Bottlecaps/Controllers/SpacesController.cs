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
    public class SpacesController : ControllerBase
    {
        private readonly BottlecapsContext _context;

        public SpacesController(BottlecapsContext context)
        {
            _context = context;
        }

        // GET: api/Spaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Space>>> GetSpace()
        {
            return await _context.Space.ToListAsync();
        }

        // GET: api/Spaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Space>> GetSpace(int id)
        {
            var space = await _context.Space.FindAsync(id);

            if (space == null)
            {
                return NotFound();
            }

            return space;
        }

        // PUT: api/Spaces/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpace(int id, Space space)
        {
            if (id != space.SpaceId)
            {
                return BadRequest();
            }

            _context.Entry(space).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceExists(id))
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
        public class PostedSpace
        {
            //public SpaceId?: number;
            public string SpaceId { get; set; }
            //public SpaceName: string;
            public string SpaceName { get; set; }
            //public ActiveStatus: string;
            public string ActiveStatus { get; set; }
            //public BackgroundImage: string;
            public string BackgroundImage { get; set; }

            //public DefaultBottlecapId: number;
            public string DefaultBottlecapId { get; set; }

            //public ProfileId: number;
            public string ProfileId { get; set; }
        }
        // POST: api/Spaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Space>> PostSpace([FromBody]PostedSpace postedSpace)
        //public void PostSpace([FromBody]PostedSpace postedSpace)
        {
            Space space = new Space();
            //space.SpaceId = Int32.Parse(postedSpace.SpaceId); //TODO: ADD TRY/CATCH
            space.SpaceId = _context.Space.Any() ? _context.Space.Select(sp => sp.SpaceId).Max() + 1 : 1;
            space.SpaceName = postedSpace.SpaceName;
            space.ActiveStatus = postedSpace.ActiveStatus;
            space.BackgroundImage = postedSpace.BackgroundImage;
            space.DefaultBottlecapId = null;
            space.ProfileId = null;

            Console.WriteLine(postedSpace);
            _context.Space.Add(space);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpaceExists(space.SpaceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpace", new { id = space.SpaceId }, space);
        }

        // DELETE: api/Spaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Space>> DeleteSpace(int id)
        {
            var space = await _context.Space.FindAsync(id);
            if (space == null)
            {
                return NotFound();
            }

            _context.Space.Remove(space);
            await _context.SaveChangesAsync();

            return space;
        }

        private bool SpaceExists(int id)
        {
            return _context.Space.Any(e => e.SpaceId == id);
        }
    }
}
