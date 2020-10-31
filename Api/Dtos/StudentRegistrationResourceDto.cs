using System;

namespace Api.Dtos {
    public class StudentRegistrationResourceDto {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string PhysicalAddress { get; set; }
        
        public int Program { get; set; }        
        
        public int AcademicLevel { get; set; }
        
        public bool Registered { get; set; }
    }
}