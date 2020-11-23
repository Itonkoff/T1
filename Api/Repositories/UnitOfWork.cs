using System.Threading.Tasks;
using Api.Contexts;
using Api.Repositories.Base.BookHasStudentRepository;
using Api.Repositories.Base.BookRepository;
using Api.Repositories.Base.CanteenBalanceRepository;
using Api.Repositories.Base.CanteenPricelistRepository;
using Api.Repositories.Base.Levels;
using Api.Repositories.Base.Module;
using Api.Repositories.Base.ModuleHasAcademicLevel;
using Api.Repositories.Base.ModuleHasProgram;
using Api.Repositories.Base.ModuleHasWeek;
using Api.Repositories.Base.Program;
using Api.Repositories.Base.StaffRepository;
using Api.Repositories.Base.StudentHasModuleHAsAcademicLevel;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public class UnitOfWork : IUnitOfWork {
        public StudentRepository.StudentRepository _StudentRepository;
        public StaffRepository.StaffRepository _StaffRepository;
        public BookRepository.BookRepository _BookRepository { get; set; }
        public BookHasStudentRepository.BookHasStudentRepository _BookHasStudentRepository { get; set; }
        public CanteenPriceListListRepository _CanteenPriceListListRepository { get; set; }
        public CanteenBalanceRepository.CanteenBalanceRepository _CanteenBalanceRepository { get; set; }
        public ProgramRepository _ProgramRepository { get; set; }
        public ILevelsRepository _LevelsRepository { get; set; }
        private IModuleRepository _ModuleRepository { get; set; }
        public IModuleHasAcademicLevelRepository _ModuleHasAcademicLevelRepository { get; set; }
        public IModuleHasProgramRepository _ModuleHasProgramRepository { get; set; }
        public IModuleHasWeekRepository _ModuleHasWeekRepository { get; set; }
        public IStudentHasModuleRepository _StudentHasModuleRepository { get; set; }

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

        public IProgramRepository ProgramRepository =>
            _ProgramRepository = _ProgramRepository ??
                                 new ProgramRepository(_context);

        public ILevelsRepository LevelsRepository =>
            _LevelsRepository = _LevelsRepository ??
                                new LevelsRepository(_context);

        public IModuleRepository ModuleRepository =>
            _ModuleRepository = _ModuleRepository ??
                                new ModuleRepository(_context);

        public IModuleHasAcademicLevelRepository ModuleHasAcademicLevelRepository =>
            _ModuleHasAcademicLevelRepository = _ModuleHasAcademicLevelRepository ??
                                                new ModuleHasAcademicLevelRepository(_context);

        public IModuleHasProgramRepository ModuleHasProgramRepository =>
            _ModuleHasProgramRepository = _ModuleHasProgramRepository ??
                                          new ModuleHasProgramRepository(_context);

        public IModuleHasWeekRepository ModuleHasWeekRepository =>
            _ModuleHasWeekRepository = _ModuleHasWeekRepository ??
                                       new ModuleHasWeekRepository(_context);

        public IStudentHasModuleRepository StudentHasModuleRepository =>
            _StudentHasModuleRepository = _StudentHasModuleRepository ??
                                          new StudentHasModuleRepository(_context);


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