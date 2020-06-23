using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bottlecaps.Models;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IEnumerable<Bottlecap>>> GetSpace()
        {
            List<Bottlecap> placedBottlecaps = new List<Bottlecap>();
            //TODO: REFACTOR THIS SO IT JUST RETURNS THE PROFILEiD COLUMN FROM SPACE TABLE
            var allSpaces = await _context.Space.ToListAsync();
            string sql = "SELECT  bc.BottlecapId" +
                ", bc.Color" +
                ", bc.ProfileId" +
                ", sp.ProfileId" +
                ", bc.Title" +
                "FROM  dbo.Space sp" +
                "LEFT JOIN Bottlecap bc" +
                "ON sp.ProfileId = bc.ProfileId;";
 
            foreach (Space space in allSpaces)
            {
                //finds all (space)bottlecaps that have been placed in space
                //Bottlecap _bottlecap = await _context.Bottlecap.FindAsync(Int32.Parse(space.DefaultBottlecapId)); //TODO: THIS IS DUMB
                //Bottlecap _bottlecap = await _context.Bottlecap.FindAsync(space.ProfileId);
                //placedBottlecaps.Add(_bottlecap);

                //placedBottlecaps = await _context.Bottlecap.Where(bc => bc.ProfileId == space.ProfileId).ToListAsync();
                //TODO: REFACTOR THIS INTO A JOIN
                List<Bottlecap> aProfilesCaps = await _context.Bottlecap.Where(bc => bc.ProfileId == space.ProfileId).ToListAsync();
                foreach (Bottlecap bottlecap in aProfilesCaps)
                {
                    bottlecap.ProfileId = null;
                    placedBottlecaps.Add(bottlecap);
                }
            }
            foreach (Bottlecap bottlecap in placedBottlecaps)
            {
                //Builds bottlecap on server
                Bottlecap _placedBottlecap = new Bottlecap();
                _placedBottlecap.Title = bottlecap.Title; //TODO: DELETE THIS

                List<Link> _links = await _context.Link.Where(lnk => lnk.BottlecapId == bottlecap.BottlecapId).ToListAsync();
                _placedBottlecap.Link = _links;
                
                List<Tag> _tags = await _context.Tag.Where(tag => tag.BottlecapId == bottlecap.BottlecapId).ToListAsync();
                _placedBottlecap.Tag = _tags;
            }
            return placedBottlecaps;
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

        // TODO: space.profileID must be used to update the x,y position
        // PUT: api/Spaces/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpace(string id, Space space)
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
            public int BottlecapId { get; set; }
        }
        // POST: api/Spaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Space>> PostSpace([FromBody]PostedSpace postedSpace)
        //public void PostSpace([FromBody]PostedSpace postedSpace)
        {
            string userId = HttpContext.User.Claims.First().Value;
            Bottlecap _bottlecap = await _context.Bottlecap.FindAsync(postedSpace.BottlecapId);
            Space space = new Space();
            //space.SpaceId = Int32.Parse(postedSpace.SpaceId); //TODO: ADD TRY/CATCH
            //var max = (_context.Space.Select(sp => sp.SpaceId).Max() + 1).ToString();
            //space.SpaceId = _context.Space.Any() ? max : 1.ToString();
            string obj = Guid.NewGuid().ToString();
            
            space.SpaceId = obj; //TODO: CHECK FOR SAME GUID?
            space.SpaceName = postedSpace.SpaceName;
            space.ActiveStatus = postedSpace.ActiveStatus;
            space.BackgroundImage = postedSpace.BackgroundImage;
            space.DefaultBottlecapId = postedSpace.BottlecapId.ToString();
            space.ProfileId = userId;

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

        private bool SpaceExists(string id)
        {
            return _context.Space.Any(e => e.SpaceId == id);
        }
    }
}
