using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class WeekDay
    {
        public WeekDay()
        {
            ModuleHasAcademicLevelHasWeekDay = new HashSet<ModuleHasAcademicLevelHasWeekDay>();
        }

        public int IdweekDays { get; set; }
        public string Value { get; set; }

        public virtual ICollection<ModuleHasAcademicLevelHasWeekDay> ModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}
