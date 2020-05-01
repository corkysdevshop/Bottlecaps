using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Session
    {
        public Session()
        {
            Message = new HashSet<Message>();
        }

        public int SessionId { get; set; }
        public DateTime? SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }
        public string SuccessfulConnection { get; set; }
        public int? ConnecteeId { get; set; }
        public int? ConnectorId { get; set; }
        public int? SpaceId { get; set; }

        public virtual Space Space { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
