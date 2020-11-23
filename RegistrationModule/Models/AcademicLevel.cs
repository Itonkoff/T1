using System;
using System.Collections.Generic;

namespace RegistrationModule.Models
{
    public partial class AcademicLevel
    {
        public AcademicLevel()
        {
            Student = new HashSet<Student>();
        }  

        public int Id { get; set; }
        public double Value { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
