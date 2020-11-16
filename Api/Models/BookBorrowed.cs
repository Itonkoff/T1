using System;

namespace Api.Models {
    public class BookBorrowed {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public bool Returned { get; set; }
        public DateTime BorrowedDate { get; set; }
        public double Fine { get; set; }
    }
}