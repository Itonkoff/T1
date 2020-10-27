using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class DaysAllowable
    {
        public DaysAllowable()
        {
            Book = new HashSet<Book>();
        }

        public int DaysAllowablecol { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
