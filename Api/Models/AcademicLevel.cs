using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class AcademicLevel
    {
        public AcademicLevel()
        {
            ModuleHasAcademicLevel = new HashSet<ModuleHasAcademicLevel>();
            Student = new HashSet<Student>();
        }

        public int IdacademicLevel { get; set; }
        public double Value { get; set; }

        public virtual ICollection<ModuleHasAcademicLevel> ModuleHasAcademicLevel { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
