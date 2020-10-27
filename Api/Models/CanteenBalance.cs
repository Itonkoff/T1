using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class CanteenBalance
    {
        public int Student { get; set; }
        public double? Cr { get; set; }
        public double? Dr { get; set; }
        public int? UserId { get; set; }

        public virtual Student StudentNavigation { get; set; }
    }
}
