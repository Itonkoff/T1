using RegistrationModule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationModule.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string PhysicalAddress { get; set; }
        
        public int AcademicLevel { get; set; }
        
        public int Program { get; set; }
        
        public bool Registered { get; set; }        
        
        public Guid RegNumber { get; set; }
        [Browsable(false)]
        public virtual AcademicLevel AcademicLevelNavigation { get; set; }
        [Browsable(false)]
        public virtual StudentProgram StudentProgramNavigation { get; set; }
    }
}
