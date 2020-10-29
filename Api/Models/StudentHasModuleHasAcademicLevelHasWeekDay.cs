using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class StudentHasModuleHasAcademicLevelHasWeekDay
    {
        public int Student { get; set; }
        public int Module { get; set; }
        public int AcademicLevel { get; set; }
        public int WeekDay { get; set; }
        public DateTime Date { get; set; }

        public virtual ModuleHasAcademicLevelHasWeekDay ModuleHasAcademicLevelHasWeekDay { get; set; }
        public virtual Student StudentNavigation { get; set; }
    }
}
