using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.ModuleHasAcademicLevel {
    public class ModuleHasAcademicLevelRepository :Repository<Models.ModuleHasAcademicLevel>,IModuleHasAcademicLevelRepository{
        public ModuleHasAcademicLevelRepository(DbContext context) : base(context)
        {
        }
    }
}