using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models {
    public partial class Student {
        public Student()
        {
            BookHasStudent = new HashSet<BookHasStudent>();
            StudentHasModuleHasAcademicLevelHasWeekDay = new HashSet<StudentHasModuleHasAcademicLevelHasWeekDay>();
            CanteenBalance = new HashSet<CanteenBalance>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string PhysicalAddress { get; set; }
        public int AcademicLevel { get; set; }
        public int Program { get; set; }
        public bool Registered { get; set; }
        public Guid RegNumber { get; set; }
        public Guid? UserId { get; set; }

        public virtual AcademicLevel AcademicLevelNavigation { get; set; }
        public virtual StudentProgram StudentProgramNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CanteenBalance> CanteenBalance { get; set; }
        public virtual ICollection<BookHasStudent> BookHasStudent { get; set; }

        public virtual ICollection<StudentHasModuleHasAcademicLevelHasWeekDay>
            StudentHasModuleHasAcademicLevelHasWeekDay { get; set; }
    }
}