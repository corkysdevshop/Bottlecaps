using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Bottlecap = new HashSet<Bottlecap>();
            Message = new HashSet<Message>();
            Space = new HashSet<Space>();
        }

        public string ProfileId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LockedProfile { get; set; }
        public string AuthorizedSpaceId { get; set; }
        public string AuthorizedUser { get; set; }
        public string ProfileCap { get; set; }

        public virtual ICollection<Bottlecap> Bottlecap { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Space> Space { get; set; }
    }
}
