using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.ModuleHasProgram {
    public class ModuleHasProgramRepository : Repository<Models.ModuleHasProgram>, IModuleHasProgramRepository {
        public ModuleHasProgramRepository(DbContext context) : base(context)
        {
        }
    }
}