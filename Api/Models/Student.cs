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

        public int Idstudent { get; set; }
        public int AcademicLevel { get; set; }
        public int Program { get; set; }
        public short Registered { get; set; }
        public int UserId { get; set; }

        public virtual AcademicLevel AcademicLevelNavigation { get; set; }
        public virtual Program ProgramNavigation { get; set; }
        public virtual CanteenBalance CanteenBalance { get; set; }
        public virtual ICollection<BookHasStudent> BookHasStudent { get; set; }
        public virtual ICollection<StudentHasModuleHasAcademicLevelHasWeekDay> StudentHasModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}
