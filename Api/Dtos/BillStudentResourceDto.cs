using System;

namespace Api.Dtos {
    public class BillStudentResourceDto {
        public Guid StudentRef { get; set; }
        public double Amount { get; set; }
    }
}