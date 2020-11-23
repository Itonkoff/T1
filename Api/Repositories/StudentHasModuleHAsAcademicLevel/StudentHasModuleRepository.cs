using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.StudentHasModuleHAsAcademicLevel {
    public class StudentHasModuleRepository : Repository<StudentHasModuleHasAcademicLevelHasWeekDay>,
        IStudentHasModuleRepository {
        public StudentHasModuleRepository(DbContext context) : base(context)
        {
        }
    }
}