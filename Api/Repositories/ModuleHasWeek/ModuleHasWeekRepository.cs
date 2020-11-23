using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.ModuleHasWeek {
    public class ModuleHasWeekRepository:Repository<ModuleHasAcademicLevelHasWeekDay>,IModuleHasWeekRepository {
        public ModuleHasWeekRepository(DbContext context) : base(context)
        {
        }
    }
}