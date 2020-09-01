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
        // THIS GETS ALL THE SPACES IN THE SPACES TABLE AND TRANSFORMS THEM INTO BOTTLECAPS
        // GET: api/Spaces
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bottlecap>>> GetSpace()
        {
            List<Bottlecap> placedBottlecaps = new List<Bottlecap>();
            //TODO: REFACTOR THIS SO IT JUST RETURNS THE PROFILEiD COLUMN FROM SPACE TABLE
            List<Space> allSpaces = await _context.Space.ToListAsync();
            //string sql = "SELECT  bc.BottlecapId " +
            //    ", bc.Color " +
            //    ", bc.ProfileId " +
            //    ", sp.ProfileId " +
            //    ", bc.Title " +
            //    "FROM  Space sp " +
            //    "LEFT JOIN Bottlecap bc " +
            //    "ON sp.ProfileId = bc.ProfileId; ";
            //var response = await _context.Database.ExecuteSqlRawAsync(sql);
 
            foreach (Space space in allSpaces)
            {
                //finds all (space)bottlecaps that have been placed in space
                //Bottlecap _bottlecap = await _context.Bottlecap.FindAsync(Int32.Parse(space.DefaultBottlecapId)); //TODO: THIS IS DUMB
                //Bottlecap _bottlecap = await _context.Bottlecap.FindAsync(space.ProfileId);
                //placedBottlecaps.Add(_bottlecap);

                //placedBottlecaps = await _context.Bottlecap.Where(bc => bc.ProfileId == space.ProfileId).ToListAsync();

                //TODO: REFACTOR THIS INTO A JOIN
                try
                {
                   List<Bottlecap> allProfilesCaps = await _context.Bottlecap.Where(bc => bc.ProfileId == space.ProfileId).ToListAsync();
                   List<Bottlecap> placedProfileCaps = allProfilesCaps.Where(pc => pc.BottlecapId == Int32.Parse(space.DefaultBottlecapId)).ToList(); 
                    if (placedProfileCaps.Any())
                    {
                        foreach (Bottlecap bottlecap in placedProfileCaps)
                        {
                            bottlecap.ProfileId = null;
                            bottlecap.PositionX = space.PositionX;
                            bottlecap.PositionY = space.PositionY;
                            placedBottlecaps.Add(bottlecap);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            foreach (Bottlecap bottlecap in placedBottlecaps)
            {
                //Builds bottlecap on server
                Bottlecap _placedBottlecap = new Bottlecap();
                _placedBottlecap.Title = bottlecap.Title; //TODO: DELETE THIS
                //bottlecap.PositionX = bottlecap.PositionX;
                //bottlecap.PositionY = bottlecap.PositionY;

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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpace([FromBody]PostedSpace space)
        {
            string spaceId = space.SpaceId;
            var spaceFromMemory = _context.Space.Where(sp => sp.DefaultBottlecapId == space.SpaceId).Single();

            spaceFromMemory.PositionX = space.PositionX;
            spaceFromMemory.PositionY = space.PositionY;

            _context.Entry(spaceFromMemory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(spaceFromMemory);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            //return NoContent();
        }
        // POST: api/Spaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Space>> PostSpace([FromBody]PostedSpace postedSpace)
        //public void PostSpace([FromBody]PostedSpace postedSpace)
        {
            string userId = HttpContext.User.Claims.First().Value; //TODO: CHECK IF I NEED TO USE THE AUTHORIZE DECORATOR OR IF I CAN JUST USE A USERID TO CHECK OR SOMETHING

            Space space = new Space();
            //space.SpaceId = Int32.Parse(postedSpace.SpaceId); //TODO: ADD TRY/CATCH
            //var max = (_context.Space.Select(sp => sp.SpaceId).Max() + 1).ToString();
            //space.SpaceId = _context.Space.Any() ? max : 1.ToString();
            string obj = Guid.NewGuid().ToString("N");
            
            space.SpaceId = obj; //TODO: CHECK FOR SAME GUID?
            space.SpaceName = postedSpace.SpaceName;
            space.ActiveStatus = postedSpace.ActiveStatus;
            space.BackgroundImage = postedSpace.BackgroundImage;
            space.PositionX = "0";
            space.PositionY = "0";
            space.DefaultBottlecapId = postedSpace.SpaceId.ToString(); //THIS CHANGES PLACES ON THE OBJECT BECAUSE ONCE ITS IN THE WILD, THE SPACE NEEDS A GUID. THIS postedSpace.SpaceId is the original Bottlecap.BottlecapId (PK)
            //TODO: THIS IS BAD, IT ALL SHOULD BE STRING OR INT

            space.ProfileId = userId;

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
