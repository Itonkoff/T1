using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class StudentProgram
    {
        public StudentProgram()
        {
            ModuleHasProgram = new HashSet<ModuleHasProgram>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ModuleHasProgram> ModuleHasProgram { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
