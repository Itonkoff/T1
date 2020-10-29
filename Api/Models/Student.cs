using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class Student
    {
        public Student()
        {
            BookHasStudent = new HashSet<BookHasStudent>();
            StudentHasModuleHasAcademicLevelHasWeekDay = new HashSet<StudentHasModuleHasAcademicLevelHasWeekDay>();
        }

        public int Id { get; set; }
        public int AcademicLevel { get; set; }
        public int Program { get; set; }
        public short Registered { get; set; }
        public Guid UserId { get; set; }

        public virtual AcademicLevel AcademicLevelNavigation { get; set; }
        public virtual StudentProgram StudentProgramNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual CanteenBalance CanteenBalance { get; set; }
        public virtual ICollection<BookHasStudent> BookHasStudent { get; set; }
        public virtual ICollection<StudentHasModuleHasAcademicLevelHasWeekDay> StudentHasModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}
