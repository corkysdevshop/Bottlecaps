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

        public int SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string ActiveStatus { get; set; }
        public string BackgroundImage { get; set; }
        public int? DefaultBottlecapId { get; set; }
        public string ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
