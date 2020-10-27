using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class BookHasStudent
    {
        public int Book { get; set; }
        public int Student { get; set; }
        public DateTime Date { get; set; }
        public short? Paid { get; set; }
        public int UserId { get; set; }

        public virtual Book BookNavigation { get; set; }
        public virtual Student StudentNavigation { get; set; }
    }
}
