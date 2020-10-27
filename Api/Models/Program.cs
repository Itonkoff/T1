using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Program
    {
        public Program()
        {
            ModuleHasProgram = new HashSet<ModuleHasProgram>();
            Student = new HashSet<Student>();
        }

        public int Idprogram { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ModuleHasProgram> ModuleHasProgram { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
