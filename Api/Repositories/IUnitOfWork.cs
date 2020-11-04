using System;
using System.Threading.Tasks;
using Api.Repositories.Base.StaffRepository;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IStaffRepository StaffMembers { get; }
        Task<int> CommitAsync();
    }
}