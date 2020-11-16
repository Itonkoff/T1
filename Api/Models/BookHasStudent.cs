using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class BookHasStudent
    {
        public int Book { get; set; }
        public int Student { get; set; }
        public DateTime DateBorrowed { get; set; }
        public bool Returned { get; set; }

        public DateTime? DateReturned { get; set; }
        public bool Paid { get; set; }
        
        public virtual Book BookNavigation { get; set; }
        public virtual Student StudentNavigation { get; set; }
    }
}
