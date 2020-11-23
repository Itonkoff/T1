using System;
using System.Threading.Tasks;
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
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IStaffRepository StaffMembers { get; }
        IBookRepository BookRepository { get; }
        IBookHasStudentRepository BookHasStudentRepository { get; }
        ICanteenBalanceRepository CanteenBalanceRepository { get; }
        ICanteenPriceListRepository CanteenPriceListRepository { get; }
        IProgramRepository ProgramRepository { get; }
        ILevelsRepository LevelsRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IModuleHasAcademicLevelRepository ModuleHasAcademicLevelRepository { get; }
        IModuleHasProgramRepository ModuleHasProgramRepository { get; }
        IModuleHasWeekRepository ModuleHasWeekRepository { get; }
        IStudentHasModuleRepository StudentHasModuleRepository { get; }
        Task<int> CommitAsync();
    }
}