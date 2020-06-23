using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Space
    {
        public Space()
        {
            Session = new HashSet<Session>();
        }

        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string ActiveStatus { get; set; }
        public string BackgroundImage { get; set; }
        public string DefaultBottlecapId { get; set; }
        public string ProfileId { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
