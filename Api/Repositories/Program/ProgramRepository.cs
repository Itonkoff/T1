using Api.Contexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base.Program {
    public class ProgramRepository : Repository<StudentProgram>, IProgramRepository {
        public ProgramRepository(DbContext context) : base(context)
        {
        }

        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}