using System;

namespace Api.Dtos {
    public class BorrowBookResourceDto {
        public int Book { get; set; }
        public Guid StudentId { get; set; }
    }
}