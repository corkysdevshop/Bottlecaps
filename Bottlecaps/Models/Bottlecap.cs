using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Bottlecap
    {
        public Bottlecap()
        {
            Link = new HashSet<Link>();
            Tag = new HashSet<Tag>();
        }

        public int BottlecapId { get; set; }
        public string Color { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public int? ProfileId { get; set; }
        public string Title { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Link> Link { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
    }
}
