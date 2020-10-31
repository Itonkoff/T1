using System.Threading.Tasks;
using Api.Contexts;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public class UnitOfWork: IUnitOfWork {

        public StudentRepository.StudentRepository _StudentRepository;
        private DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        
        public IStudentRepository Students =>
            _StudentRepository = _StudentRepository ?? new StudentRepository.StudentRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}