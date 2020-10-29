using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Book
    {
        public Book()
        {
            BookHasStudent = new HashSet<BookHasStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
        public int DaysAllowable { get; set; }
        public int PenaltyRate { get; set; }

        public virtual DaysAllowable DaysAllowableNavigation { get; set; }
        public virtual PenaltyRate PenaltyRateNavigation { get; set; }
        public virtual ICollection<BookHasStudent> BookHasStudent { get; set; }
    }
}
