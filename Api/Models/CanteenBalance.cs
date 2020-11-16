using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class CanteenBalance
    {
        public int Id { get; set; }
        public int Student { get; set; }
        public DateTime Date { get; set; }
        public double? Cr { get; set; }
        public double? Dr { get; set; }

        public virtual Student StudentNavigation { get; set; }
    }
}
