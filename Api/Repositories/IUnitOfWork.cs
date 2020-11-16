using System;
using System.Threading.Tasks;
using Api.Repositories.Base.BookHasStudentRepository;
using Api.Repositories.Base.BookRepository;
using Api.Repositories.Base.CanteenBalanceRepository;
using Api.Repositories.Base.CanteenPricelistRepository;
using Api.Repositories.Base.StaffRepository;
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
        Task<int> CommitAsync();
    }
}