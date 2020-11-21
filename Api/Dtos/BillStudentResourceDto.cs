using System;

namespace Api.Dtos {
    public class BillStudentResourceDto {
        public Guid StudentRef { get; set; }
        public int Amount { get; set; }
    }
}