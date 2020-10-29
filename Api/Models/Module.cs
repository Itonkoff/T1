using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Module
    {
        public Module()
        {
            ModuleHasAcademicLevel = new HashSet<ModuleHasAcademicLevel>();
            ModuleHasProgram = new HashSet<ModuleHasProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ModuleHasAcademicLevel> ModuleHasAcademicLevel { get; set; }
        public virtual ICollection<ModuleHasProgram> ModuleHasProgram { get; set; }
    }
}
