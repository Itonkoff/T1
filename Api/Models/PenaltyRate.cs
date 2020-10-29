using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class PenaltyRate
    {
        public PenaltyRate()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
