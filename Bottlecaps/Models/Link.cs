using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Link
    {
        public int LinkId { get; set; }
        public string LinkText { get; set; }
        public int? BottlecapId { get; set; }

        public virtual Bottlecap Bottlecap { get; set; }
    }
}
