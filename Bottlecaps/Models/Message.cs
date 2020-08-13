using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public DateTime? MessageDateTime { get; set; }
        public string Message1 { get; set; }
        public int? SessionId { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }

        public virtual Profile Sender { get; set; }
        public virtual Session Session { get; set; }
    }
}
