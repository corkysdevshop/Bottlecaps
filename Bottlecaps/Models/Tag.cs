using System;
using System.Collections.Generic;

namespace Bottlecaps.Models
{
    public partial class Tag
    {
        public int TagId { get; set; }
        public string TagText { get; set; }
        public int? BottlecapId { get; set; }

        public virtual Bottlecap Bottlecap { get; set; }
    }
}
