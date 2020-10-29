using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class BookHasStudent
    {
        public int Book { get; set; }
        public int Student { get; set; }
        public DateTime DateBorrowed { get; set; }
        public short? Paid { get; set; }
        public Guid UserId { get; set; }

        public virtual Book BookNavigation { get; set; }
        public virtual Student StudentNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
