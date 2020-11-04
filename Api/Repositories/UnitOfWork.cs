using System.Threading.Tasks;
using Api.Contexts;
using Api.Repositories.Base.StaffRepository;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public class UnitOfWork: IUnitOfWork {

        public StudentRepository.StudentRepository _StudentRepository;
        public StaffRepository.StaffRepository _StaffRepository;
        private DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        
        public IStudentRepository Students =>
            _StudentRepository = _StudentRepository ?? new StudentRepository.StudentRepository(_context);

        public IStaffRepository StaffMembers =>
            _StaffRepository = _StaffRepository ?? new StaffRepository.StaffRepository(_context);

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