using System.Threading.Tasks;
using Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.Module {
    public class ModuleRepository : Repository<Models.Module>, IModuleRepository {
        public ModuleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Models.Module> GetFullModule(int module)
        {
            return await DatabaseContext.Module
                .Include(m => m.ModuleHasProgram)
                .Include(m => m.ModuleHasAcademicLevel)
                .SingleOrDefaultAsync(m => m.Id == module);
        }
        
        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}