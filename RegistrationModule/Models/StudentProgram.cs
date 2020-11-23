using System;
using System.Collections.Generic;

namespace RegistrationModule.Models
{
    public partial class StudentProgram
    {
        public StudentProgram()
        {
            Student = new HashSet<Student>();
        } 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Student> Student { get; set; }
    }
}
