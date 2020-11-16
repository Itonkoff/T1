using System.Threading.Tasks;
using Api.Contexts;
using Api.Repositories.Base.BookHasStudentRepository;
using Api.Repositories.Base.BookRepository;
using Api.Repositories.Base.CanteenBalanceRepository;
using Api.Repositories.Base.CanteenPricelistRepository;
using Api.Repositories.Base.StaffRepository;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public class UnitOfWork : IUnitOfWork {
        public StudentRepository.StudentRepository _StudentRepository;
        public StaffRepository.StaffRepository _StaffRepository;
        public BookRepository.BookRepository _BookRepository { get; set; }
        public BookHasStudentRepository.BookHasStudentRepository _BookHasStudentRepository { get; set; }
        public CanteenPriceListListRepository _CanteenPriceListListRepository { get; set; }
        public CanteenBalanceRepository.CanteenBalanceRepository _CanteenBalanceRepository { get; set; }
        private DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IStudentRepository Students =>
            _StudentRepository = _StudentRepository ?? new StudentRepository.StudentRepository(_context);

        public IStaffRepository StaffMembers =>
            _StaffRepository = _StaffRepository ?? new StaffRepository.StaffRepository(_context);

        public IBookRepository BookRepository =>
            _BookRepository = _BookRepository ?? new BookRepository.BookRepository(_context);

        public IBookHasStudentRepository BookHasStudentRepository =>
            _BookHasStudentRepository = _BookHasStudentRepository ??
                                        new BookHasStudentRepository.BookHasStudentRepository(_context);

        public ICanteenBalanceRepository CanteenBalanceRepository =>
            _CanteenBalanceRepository = _CanteenBalanceRepository ??
                                        new CanteenBalanceRepository.CanteenBalanceRepository(_context);
        

        public ICanteenPriceListRepository CanteenPriceListRepository =>
            _CanteenPriceListListRepository = _CanteenPriceListListRepository ??
                                              new CanteenPriceListListRepository(_context);
        

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