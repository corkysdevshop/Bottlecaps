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
    public class BottlecapsController : ControllerBase
    {
        private readonly BottlecapsContext _context;

        public BottlecapsController(BottlecapsContext context)
        {
            _context = context;
        }

        // GET: api/Bottlecaps TODO: THIS METHOD CAN PROBABLY GET DELETED
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bottlecap>>> GetBottlecap()
        {            
            return await _context.Bottlecap.ToListAsync();
        }

        //TODO: ADD AUTHORIZED HEADERS TO ALL RELEVANT METHODS
        // GET: api/Bottlecaps/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bottlecap>> GetBottlecap(int id)
        {
            var bottlecap = await _context.Bottlecap.FindAsync(id);

            if (bottlecap == null)
            {
                return NotFound();
            }

            return bottlecap;
        }

        //TODO: THIS METHOD CAN PROBABLY GET DELETED NOW THAT THE USERID IS DELIVERED IN THE HEADER TOKEN, THERE IS NO LONGER A REASON TO SEND THE PROFILE ID THROUGH THE URL
        //TODO: DELETE THE PROFILEID SIGNATURE ON THIS METHOD
        // GET: api/Bottlecaps/5
        [Authorize]
        [HttpGet("mybottlecaps/{profileId}")]
        public async Task<ActionResult<IEnumerable<Bottlecap>>> GetBottlecaps()
        {
            //var bottlecap = await _context.Bottlecap.FindAsync(id);
            string userId = HttpContext.User.Claims.First().Value;
            var bottlecaps = await _context.Bottlecap.Where(bc => bc.ProfileId == userId)
                .ToListAsync();
            
            if (bottlecaps == null)
            {
                return NotFound();
            }

            return bottlecaps;
        }

        // PUT: api/Bottlecaps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBottlecap(int id, Bottlecap bottlecap)
        {
            if (id != bottlecap.BottlecapId)
            {
                return BadRequest();
            }

            _context.Entry(bottlecap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BottlecapExists(id))
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

        // POST: api/Bottlecaps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.


        public class PostedBottlecap
        {
            public string title { get; set; }
            public PostedProfile profile { get; set; }
            public ICollection<PostedTag>  tag { get; set; }
            public ICollection<PostedLink> link { get; set; }
            public class PostedProfile
            {
                public int ProfileId { get; set; }
            }
            public class PostedTag
            {
                public string tagText { get; set; }
            }
            public class PostedLink
            {
                public string linkText { get; set; }
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Bottlecap>> PostBottlecap([FromBody]PostedBottlecap bottlecapInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HttpContext.User.Claims.First().Value;

            //ADD BOTTLECAP
            Bottlecap bottlecap = new Bottlecap();
            //TODO: MAKE THESE INTO SOMETHING LIKE A GUID, BUT MORE PERFORMANCE
            bottlecap.BottlecapId = _context.Bottlecap.Any() ? _context.Bottlecap.Select(bc => bc.BottlecapId).Max() + 1 : 1;
            bottlecap.Title = bottlecapInput.title;
            bottlecap.ProfileId = userId;
            _context.Bottlecap.Add(bottlecap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BottlecapExists(bottlecap.BottlecapId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //ADD TAGS
            int newTagId = _context.Tag.Any() ? _context.Tag.Select(t => t.TagId).Max() + 1 : 1;
            foreach (PostedBottlecap.PostedTag tag in bottlecapInput.tag)
            {
                Tag newTag = new Tag();
                newTag.TagText = tag.tagText;
                newTag.BottlecapId = bottlecap.BottlecapId;
                newTag.TagId = newTagId;
                _context.Tag.Add(newTag);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (_context.Tag.Any(t => t.TagId == newTagId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                newTagId++;
            }

            //ADD LINKS
            int newLinkId = _context.Tag.Any() ? _context.Tag.Select(t => t.TagId).Max() + 1 : 1;
            foreach (PostedBottlecap.PostedLink link in bottlecapInput.link)
            {
                Link newLink = new Link();
                newLink.LinkText = link.linkText;
                newLink.BottlecapId = bottlecap.BottlecapId;
                newLink.LinkId = newLinkId;
                _context.Link.Add(newLink);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (_context.Link.Any(l => l.LinkId == newLinkId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                newLinkId++;
            }

            return CreatedAtAction("GetBottlecap", new { id = bottlecap.BottlecapId }, bottlecap);
        }

        // DELETE: api/Bottlecaps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bottlecap>> DeleteBottlecap(int id)
        {
            var bottlecap = await _context.Bottlecap.FindAsync(id);
            List<Tag> tagsToDelete = await _context.Tag.Where(t => t.BottlecapId == id).ToListAsync();
            List<Link> linksToDelete = await _context.Link.Where(l => l.BottlecapId == id).ToListAsync();
            if (bottlecap == null)
            {
                return NotFound();
            }

            _context.Bottlecap.Remove(bottlecap);

            foreach (Tag tagToDelete in tagsToDelete)
            {
                _context.Tag.Remove(tagToDelete); //TODO: TRY/CATCH BLOCK LIKE POST
            }
            foreach (Link linkToDelete in linksToDelete)
            {
                _context.Link.Remove(linkToDelete); //TODO: TRY/CATCH BLOCK LIKE POST
            }

            await _context.SaveChangesAsync();

            return bottlecap;
        }

        private bool BottlecapExists(int id)
        {
            return _context.Bottlecap.Any(e => e.BottlecapId == id);
        }
    }
}
