using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ModuleHasAcademicLevel
    {
        public ModuleHasAcademicLevel()
        {
            ModuleHasAcademicLevelHasWeekDay = new HashSet<ModuleHasAcademicLevelHasWeekDay>();
        }

        public int Module { get; set; }
        public int AcademicLevel { get; set; }

        public virtual AcademicLevel AcademicLevelNavigation { get; set; }
        public virtual Module ModuleNavigation { get; set; }
        public virtual ICollection<ModuleHasAcademicLevelHasWeekDay> ModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}
