using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ModuleHasAcademicLevelHasWeekDay
    {
        public ModuleHasAcademicLevelHasWeekDay()
        {
            StudentHasModuleHasAcademicLevelHasWeekDay = new HashSet<StudentHasModuleHasAcademicLevelHasWeekDay>();
        }

        public int Module { get; set; }
        public int AcademicLevel { get; set; }
        public int WeekDay { get; set; }
        public TimeSpan Timel { get; set; }

        public virtual ModuleHasAcademicLevel ModuleHasAcademicLevel { get; set; }
        public virtual WeekDay WeekDayNavigation { get; set; }
        public virtual ICollection<StudentHasModuleHasAcademicLevelHasWeekDay> StudentHasModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}
